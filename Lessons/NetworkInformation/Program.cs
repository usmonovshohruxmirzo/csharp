using System.Net.NetworkInformation;

namespace NetworkInformation;

static class Program
{
  static async Task Main(string[] args)
  {
    bool isConnected = NetworkInterface.GetIsNetworkAvailable();
    Console.WriteLine(isConnected ? "Connected" : "Disconnected");

    var adapters = NetworkInterface.GetAllNetworkInterfaces();
    foreach (var adapter in adapters)
    {
      PhysicalAddress mac = adapter.GetPhysicalAddress();
      Console.WriteLine("{0} | {1} | {2}", adapter.Name, adapter.OperationalStatus, mac);
    }

    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("PING EXAMPLE");
    using Ping ping = new();
    PingReply reply = await ping.SendPingAsync("google.com");
    Console.WriteLine($"{reply.Address}\n{reply.Address}\n{reply.RoundtripTime}ms");
    Console.ResetColor();

    while (true)
    {
      using Ping ping1 = new();
      PingReply reply1 = await ping.SendPingAsync("google.com");
      Console.WriteLine($"{reply.Address} | {reply1.RoundtripTime}ms");
      Thread.Sleep(200);
    }
  }
}
