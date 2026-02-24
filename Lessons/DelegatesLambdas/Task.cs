namespace Task
{
  public class Order
  {
    private int Id { get; set; }
    public int Amount { get; set; }
    public bool IsPaid { get; set; }

    public Order(int id, int amount, bool isPaid)
    {
      Id = id;
      Amount = amount;
      IsPaid = isPaid;
    }
  }

  public delegate bool OrderValidator(Order order);
  public delegate void OrderHanlder(Order order);

  public class Task
  {
    public static void Run()
    {
      Console.WriteLine("Task is running...");
    }
  }
}
