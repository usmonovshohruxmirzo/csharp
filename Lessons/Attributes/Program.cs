#pragma warning disable

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

      Logger.Debug("Loading user...");
      Logger.Debug("Connecting to DB...");

      AccessingCustomAttributes();

      DllImportExample.Run();
    }

    static void AccessingCustomAttributes()
    {
      Type projectType = typeof(Project);
      var classAttributes = projectType.GetCustomAttributes(typeof(DeveloperAttribute), false);
      foreach (DeveloperAttribute attr in classAttributes)
      {
        Console.WriteLine($"Class Developer: {attr.Name}, Level: {attr.Level}");
      }

      MethodInfo[] methods = projectType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Static);
      foreach (var method in methods)
      {
        var methodAttributes = method.GetCustomAttributes(typeof(DeveloperAttribute), false);
        foreach (DeveloperAttribute attr in methodAttributes)
        {
          Console.WriteLine($"Method '{method.Name}' Developer: {attr.Name}, Level: {attr.Level}");
        }
      }
    }
  }

  class Calculator
  {
    [Obsolete("Use AddNumbers instead of Add")]
    public int Add(int a, int b)
    {
      return a + b;
    }

    public int AddNumbers(int a, int b)
    {
      return a + b;
    }
  }

  [Serializable]
  class Person
  {
    public string? Name { get; set; }
    public int Age { get; set; }
  }
}
