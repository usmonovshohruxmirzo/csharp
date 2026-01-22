using OrderProcessing.Interfaces;

namespace OrderProcessing.Tests.Stubs
{
  public class StubPaymentGateway : IPaymentGateway
  {
    private readonly bool _result;

    public StubPaymentGateway(bool result)
    {
      _result = result;
    }

    public bool Pay(decimal amount)
    {
      return _result;
    }
  }
}
