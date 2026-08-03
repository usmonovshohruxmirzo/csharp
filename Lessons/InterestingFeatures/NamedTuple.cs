namespace InterestingFeatures
{
  public class NamedTuple
  {
    public static void Run()
    {
      var tuple = (name: "Alex", age: 18);
      Console.WriteLine(tuple.name);
      Console.WriteLine(tuple.age);
    }
  }
}
