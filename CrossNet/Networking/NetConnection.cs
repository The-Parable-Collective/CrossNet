using CrossNet.Native;
using Serilog;
using System.Net;
using System.Net.Sockets;

namespace CrossNet.Networking;

public sealed class NetConnection
{
    private readonly IPEndPoint endPoint;

    private byte[] nativeAddress = [];

    private readonly SocketAddress cachedSocketAddress;

    internal NetConnection(IPEndPoint endPoint)
    {
        this.endPoint = endPoint;
        this.cachedSocketAddress = this.endPoint.Serialize();
        this.GenerateNativeAddress();
    }

    private void GenerateNativeAddress()
    {
        this.nativeAddress = new byte[this.cachedSocketAddress.Size];
        for (int i = 0; i < this.cachedSocketAddress.Size; i++)
        {
            this.nativeAddress[i] = this.cachedSocketAddress[i];
        }
    }

    internal MessageResult SendRawMessage(Socket socket, byte[] message, int start, int length, bool useNativeSockets)
    {
        int bytesSent = 0;
        try
        {
            if (useNativeSockets)
            {
                unsafe
                {
                    fixed (byte* dataWithOffset = &message[start])
                    {
                        bytesSent = NativeSocket.SendTo(socket.Handle, dataWithOffset, length, this.nativeAddress, this.nativeAddress.Length);
                    }
                }

                if (bytesSent == -1)
                {
                    throw NativeSocket.GetSocketException();
                }
            }
            else
            {
#if NET8_0_OR_GREATER
                bytesSent = socket.SendTo(new ReadOnlySpan<byte>(message, start, length), SocketFlags.None, this.endPoint.Serialize());
#else
                bytesSent = socket.SendTo(message, start, length, SocketFlags.None, endPoint);
#endif
            }

            Log.Debug("Sent packet to {EndPoint} : result: {Result}, bytes: {Bytes}", this.endPoint, bytesSent);
        }
        catch (SocketException exception)
        {
            switch (exception.SocketErrorCode)
            {
                case SocketError.NoBufferSpaceAvailable:
                    Log.Error(exception, "No buffer space available");
                    return new MessageResult() { ResultType = ResultType.NoBufferSpaceAvailable };

                case SocketError.Interrupted:
                    Log.Error(exception, "Message cancelled or interrupted.");
                    return new MessageResult() { ResultType = ResultType.Interrupted };

                case SocketError.MessageSize:
                    Log.Error(exception, "Message too long: {Length}.", length);
                    return new MessageResult() { ResultType = ResultType.OversizedPacket };

                case SocketError.HostUnreachable:
                case SocketError.NetworkUnreachable:
                    Log.Error(exception, "Host or network cannot be reached.");
                    return new MessageResult() { ResultType = ResultType.Unreachable };

                case SocketError.Shutdown:
                    Log.Error(exception, "Socket was already closed.");
                    return new MessageResult() { ResultType = ResultType.AlreadyClosed };

                default:
                    Log.Error(exception, "Unknown error. Check exception for details.");
                    return new MessageResult() { ResultType = ResultType.Unknown };
            }
        }
        catch (Exception exception)
        {
            Log.Error(exception, "An unhandled exception has occured while sending packet. Check exception for details.");
            return new MessageResult() { ResultType = ResultType.Unknown };
        }

        return new MessageResult() { ResultType = ResultType.Success, BytesSent = bytesSent };
    }
}