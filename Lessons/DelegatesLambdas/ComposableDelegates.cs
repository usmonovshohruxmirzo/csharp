#pragma warning disable
public class ComposableDelegates
{
  public static void Run()
  {
    FunctionalComposition();
    DelegateComposition();
  }

  private static void FunctionalComposition()
  {
    Func<int, int> doubleInt = x => x * 2;
    Func<int, int> addTen = x => x + 10;
    Func<int, int> composed = x => addTen(doubleInt(2));
    Console.WriteLine(composed(5));
  }


  delegate void Operation(ref int a, ref int b);
  private static void DelegateComposition()
  {
    Operation add = (ref int a, ref int b) =>
    {
      b += 20;
      Console.WriteLine($"Add: {a + b}");
    };
    Operation mul = (ref int a, ref int b) => Console.WriteLine($"Multiply: {a * b}");
    Operation div = (ref int a, ref int b) => Console.WriteLine($"Divide: {a / b}");
    Operation sub = (ref int a, ref int b) => Console.WriteLine($"Substarct: {a - b}");
    // Operation crash = (a, b) => throw new Exception("Boom");
    // INFO: If one delegate throws, the rest won’t run:

    Operation composed = add + mul;
    // composed += crash;
    composed += div;
    composed += sub;

    int a = 10, b = 5;
    composed(ref a, ref b);

    // INFO: Safe execution pattern
    // try
    // {
    //   composed(20, 20);
    // }
    // catch (Exception ex)
    // {
    //   Console.WriteLine(ex.Message);
    // }

    Console.WriteLine("After unsubscription");
    composed -= add;

    composed(ref a, ref b);

    int invocationCount = composed.GetInvocationList().GetLength(0);
    Console.WriteLine(invocationCount);
  }
}
