using OrderProcessing.Interfaces;
using OrderProcessing.Domain;

namespace OrderProcessing.Services
{
  public class OrderService
  {
    private readonly IPaymentGateway _payment;
    private readonly IOrderRepository _repository;
    private readonly ILogger _logger;

    public OrderService(
        IPaymentGateway payment,
        IOrderRepository repository,
        ILogger logger)
    {
      _payment = payment;
      _repository = repository;
      _logger = logger;
    }

    public bool PlaceOrder(Order order)
    {
      if (!_payment.Pay(order.Amount))
      {
        _logger.Log("Payment failed");
        return false;
      }

      _repository.Save(order);
      _logger.Log("Order saved");

      return true;
    }
  }
}
