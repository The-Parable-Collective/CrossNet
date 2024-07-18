using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CrossNetServerDummy;

internal class Program
{
    private const int PORT = 12345;
    private static readonly byte[] buffer = new byte[1024];

    public static void Main(string[] args)
    {
        try
        {
            // Establish the local endpoint for the socket (server).
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PORT);

            // Create a TCP/IP socket.
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine($"Server is listening on {localEndPoint}");

            while (true)
            {
                // Start accepting incoming connections.
                Socket handler = listener.Accept();
                Console.WriteLine($"Accepted connection from {handler.RemoteEndPoint}");

                // Receive data from the client.
                string data = null;
                int bytesReceived = handler.Receive(buffer);
                data += Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                Console.WriteLine($"Received from client: {data}");

                // Echo the data back to the client.
                handler.Send(buffer, bytesReceived, SocketFlags.None);
                Console.WriteLine($"Sent to client: {data}");

                // Close the connection.
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
}