using System.Runtime.CompilerServices;

namespace InlineArrays
{
  static class Program
  {
    static void Main()
    {
      MyBuffer buffer = default;

      buffer[0] = 5;
      buffer[1] = 10;

      Console.WriteLine(buffer[1]);
    }
  }
  [InlineArray(11)]
  public struct MyBuffer
  {
    private int _element;
  }
}
