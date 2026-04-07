using System.Diagnostics;

class SpanExample
{
  public static void Run()
  {
    int[] array = [1, 2, 3, 4, 5, 6, 7, 8, 9];
    var stopwatch = Stopwatch.StartNew();
    // var slice = array.AsSpan(5, 3);
    var slice = array.Skip(5).Take(3).ToArray();

    stopwatch.Stop();
    Console.WriteLine("time: {0:F5}ms", stopwatch.ElapsedMilliseconds);

    foreach (var num in slice)
    {
      Console.WriteLine(num);
    }

    Span<int> nums = array;
    var slice2 = nums.Slice(2, 5);
    Console.WriteLine(string.Join(", ", slice2.ToArray()));
    Console.WriteLine(string.Join(", ", nums.ToArray()));

    Memory<int> memory = array.AsMemory();
  }
}
