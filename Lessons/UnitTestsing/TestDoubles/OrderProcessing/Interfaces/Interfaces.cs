using OrderProcessing.Domain;

namespace OrderProcessing.Interfaces
{
  public interface IPaymentGateway
  {
    bool Pay(decimal amount);
  }

  public interface IOrderRepository
  {
    void Save(Order order);
    int Count();
  }

  public interface ILogger
  {
    void Log(string message);
  }
}
