using System.Reflection;

public class MethodExample
{
  public void m_public() { }
  internal void m_internal() { }
  protected void m_protected() { }
  protected internal void m_protected_public() { }
  private protected void m_private_protected() { }

  public static void Run()
  {
    Console.WriteLine("\n{0,-30}{1,-18}{2}", "", "IsAssembly", "IsFamilyOrAssembly");
    Console.WriteLine("{0,-21}{1,-18}{2,-18}{3}\n",
        "", "IsPublic", "IsFamily", "IsFamilyAndAssembly");

    foreach (MethodBase m in typeof(MethodExample).GetMethods(
        BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
    {
      if (m.Name[0..1] == "m")
      {
        Console.WriteLine(
            "{0,-21}{1,-9}{2,-9}{3,-9}{4,-9}{5,-9}",
            m.Name,
            m.IsPublic,
            m.IsAssembly,
            m.IsFamily,
            m.IsFamilyOrAssembly,
            m.IsFamilyAndAssembly
        );
      }
    }
  }
}
