public class MulticastDelegateExample
{
  delegate void Operation(int x);

  public static void Run()
  {
    Operation op1 = x => Console.WriteLine($"A: {x}");
    Operation op2 = x => Console.WriteLine($"A: {x * 2}");
    Operation combined = op1 + op2;
    MulticastDelegate md = combined;

    foreach (Delegate d in md.GetInvocationList())
    {
      d.DynamicInvoke(5);
    }
  }
}
