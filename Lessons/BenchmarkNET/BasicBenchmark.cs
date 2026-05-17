using BenchmarkDotNet.Attributes;

namespace BenchmarkNET;

public class BasicBenchmark
{
  [Benchmark]
  public int SumLoop()
  {
    int sum = 0;
    for (int i = 0; i < 1000; i++)
    {
      sum += i;
    }
    return sum;
  }

  [Benchmark]
  public int SumLinq()
  {
    return Enumerable.Range(0, 1000).Sum();
  }
}
