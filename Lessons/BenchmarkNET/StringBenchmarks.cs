using BenchmarkDotNet.Attributes;
using System.Text;

namespace BenchmarkNET;

[MemoryDiagnoser]
public class StringBenchmarks
{
  private readonly string[] words = Enumerable.Repeat("hello", 1000).ToArray();

  [Benchmark(Baseline = true)]
  public string JoinPlus()
  {
    string result = "";
    foreach (var w in words)
      result += w;

    return result;
  }

  [Benchmark]
  public string JoinStringBuilder()
  {
    var sb = new StringBuilder();
    foreach (var w in words)
      sb.Append(w);

    return sb.ToString();
  }
}
