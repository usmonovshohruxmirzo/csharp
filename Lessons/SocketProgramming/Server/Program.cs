using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server
{
  static class Program
  {
    static void Main(string[] args)
    {
      IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
      IPAddress ipAddr = ipHost.AddressList[0];
      IPEndPoint localEndpoint = new IPEndPoint(ipAddr, 11111);

      Socket listener = new(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      try
      {
        listener.Bind(localEndpoint);

        listener.Listen(10);

        while (true)
        {
          Console.WriteLine("Waiting for connection...");

          Socket clientSocket = listener.Accept();

          byte[] bytes = new byte[1024];
          string data = null!;

          while (true)
          {
            int numByte = clientSocket.Receive(bytes);
            data += Encoding.ASCII.GetString(bytes, 0, numByte);

            if (data.IndexOf("<EOF>") > -1)
            {
              break;
            }
          }

          Console.WriteLine("Text received -> {0} ", data);

          byte[] message = Encoding.ASCII.GetBytes("Test Server");

          clientSocket.Send(message);

          clientSocket.Shutdown(SocketShutdown.Both);
          clientSocket.Close();
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
