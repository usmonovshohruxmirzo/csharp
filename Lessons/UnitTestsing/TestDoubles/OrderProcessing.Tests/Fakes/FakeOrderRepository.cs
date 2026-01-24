using OrderProcessing.Interfaces;
using OrderProcessing.Domain;

namespace OrderProcessing.Tests.Fakes
{
  public class FakeOrderRepository : IOrderRepository
  {
    private readonly List<Order> _orders = [];

    public void Save(Order order)
    {
      _orders.Add(order);
    }

    public int Count()
    {
      return _orders.Count;
    }
  }
}
