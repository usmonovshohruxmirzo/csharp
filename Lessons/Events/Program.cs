namespace Events
{

  class Program
  {

    public delegate void Test(int hello);

    static void Main(string[] args)
    {
      // Order order = new Order();
      //
      // order.StatusChanged += SendEmail;
      // order.StatusChanged += LogStatus;
      //
      // order.SetStatus("Paid");
      // order.SetStatus("Shipped");

      // CountdownTimer.Run();

      StockPriceAlertSystem.Run();
    }

    // static void SendEmail(string status)
    // {
    //   Console.WriteLine($"Email sent: Order is {status}");
    // }
    //
    // static void LogStatus(string status)
    // {
    //   Console.WriteLine($"Log: Order status changed to {status}");
    // }
  }
}

