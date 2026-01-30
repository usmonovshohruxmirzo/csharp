using OrderProcessing.Tests.Dummies;
using OrderProcessing.Tests.Fakes;
using OrderProcessing.Tests.Stubs;
using OrderProcessing.Interfaces;
using OrderProcessing.Services;
using OrderProcessing.Domain;
using Moq;

namespace OrderProcessing.Tests
{
  [TestFixture]
  public class OrderServiceTests
  {
    [Test]
    public void PlaceOrder_Success_UsesAllTestDoubles()
    {
      ILogger dummyLogger = new DummyLogger();
      IPaymentGateway stubPayment = new StubPaymentGateway(true);

      var fakeRepo = new FakeOrderRepository();
      var loggerMock = new Mock<ILogger>();
      var service = new OrderService(
          stubPayment,
          fakeRepo,
          loggerMock.Object
      );

      var result = service.PlaceOrder(new Order { Id = 1, Amount = 100 });

      Assert.Multiple(() =>
      {
        Assert.That(result, Is.True);
        Assert.That(fakeRepo.Count(), Is.EqualTo(1));
      });

      loggerMock.Verify(x => x.Log("Order saved"), Times.Once);
    }

    [Test]
    public void PlaceOrder_Success_AdvancedMoqUsage()
    {
      var loggerMock = new Mock<ILogger>(MockBehavior.Strict);
      loggerMock.Setup(x => x.Log(It.IsAny<string>())).Verifiable();

      var paymentMock = new Mock<IPaymentGateway>();
      paymentMock.Setup(x => x.Pay(It.Is<decimal>(a => a > 0))).Returns(true);

      var fakeRepo = new FakeOrderRepository();
      var service = new OrderService(paymentMock.Object, fakeRepo, loggerMock.Object);
      var result = service.PlaceOrder(new Order { Id = 1, Amount = 200 });


      Assert.Multiple(() =>
      {
        Assert.That(result, Is.True);
        Assert.That(fakeRepo.Count(), Is.EqualTo(1));
      });

      paymentMock.Verify(x => x.Pay(It.Is<decimal>(a => a == 200)), Times.Once);
      loggerMock.Verify(x => x.Log(It.Is<string>(s => s.Contains("Order"))));

      loggerMock.VerifyNoOtherCalls();
      paymentMock.VerifyNoOtherCalls();
    }

    [Test]
    public void PlaceOrder_PaymentFails_ThrowsAndSkipsSave()
    {
      var loggerMock = new Mock<ILogger>();
      var paymentMock = new Mock<IPaymentGateway>();
      paymentMock.Setup(x => x.Pay(It.IsAny<decimal>())).Throws(new Exception("Payment failed"));
    }
  }
}
