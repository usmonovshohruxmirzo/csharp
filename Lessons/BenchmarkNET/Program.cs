using BenchmarkDotNet.Running;

namespace BenchmarkNET
{
  class Program
  {
    static void Main()
    {
      // BenchmarkRunner.Run<BasicBenchmark>();
      BenchmarkRunner.Run<StringBenchmarks>();
    }
  }
}
