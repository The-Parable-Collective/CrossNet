using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CrossNetClientDummy;

internal class Program
{
    private const int PORT = 12345;

    public static void Main()
    {
        try
        {
            // Establish the remote endpoint for the socket.
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEndPoint = new IPEndPoint(ipAddress, PORT);

            // Create a TCP/IP socket.
            Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Connect the socket to the remote endpoint.
            sender.Connect(remoteEndPoint);
            Console.WriteLine($"Socket connected to {sender.RemoteEndPoint}");

            // Send data to the server.
            string message = "Hello, server!";
            byte[] byteData = Encoding.ASCII.GetBytes(message);
            int bytesSent = sender.Send(byteData);
            Console.WriteLine($"Sent to server: {message}");

            // Receive the response from the server.
            byte[] buffer = new byte[1024];
            int bytesReceived = sender.Receive(buffer);
            string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
            Console.WriteLine($"Received from server: {response}");

            // Release the socket.
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}