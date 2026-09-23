using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client
{
  static class Program
  {
    static void Main(string[] args)
    {
      IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
      IPAddress ipAddr = ipHost.AddressList[0];
      IPEndPoint localEndpoint = new(ipAddr, 11111);
      Socket sender = new(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


      try
      {
        sender.Connect(localEndpoint);

        Console.WriteLine("Socket connected to -> {0}", sender.RemoteEndPoint.ToString());

        byte[] messageSent = Encoding.ASCII.GetBytes("Test Client<EOF>");
        int byteSent = sender.Send(messageSent);

        byte[] messageReceived = new byte[1024];

        int byteRecv = sender.Receive(messageReceived);
        Console.WriteLine("Message from Server -> {0}", Encoding.ASCII.GetString(messageReceived, 0, byteRecv));

        sender.Shutdown(SocketShutdown.Both);
        sender.Close();
      }

      catch (ArgumentNullException ex)
      {
        Console.WriteLine(ex.Message);
      }

      catch (SocketException ex)
      {
        Console.WriteLine(ex.Message);
      }

      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
      }
    }
  }
}
