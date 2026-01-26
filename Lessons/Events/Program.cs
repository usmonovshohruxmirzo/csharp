namespace Events
{
  class Program
  {
    static void Main(string[] args)
    {
      Order order = new Order();

      order.StatusChanged += SendEmail;
      order.StatusChanged += LogStatus;

      order.SetStatus("Paid");
      order.SetStatus("Shipped");
    }

    static void SendEmail(string status)
    {
      Console.WriteLine($"Email sent: Order is {status}");
    }

    static void LogStatus(string status)
    {
      Console.WriteLine($"Log: Order status changed to {status}");
    }
  }
}
