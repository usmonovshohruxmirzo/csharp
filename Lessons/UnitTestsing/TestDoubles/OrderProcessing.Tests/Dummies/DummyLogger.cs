using OrderProcessing.Interfaces;

namespace OrderProcessing.Tests.Dummies
{
  public class DummyLogger : ILogger
  {
    public void Log(string message) { }
  }
}
