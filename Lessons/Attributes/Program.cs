using System.Reflection;
namespace Attributes
{
  class Program
  {
    static void Main(string[] args)
    {
      Assembly assembly = typeof(int).Assembly;
      Console.WriteLine(assembly);

      MethodExample.Run();
    }
  }
}
