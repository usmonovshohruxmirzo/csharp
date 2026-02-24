namespace ActivatorDemo
{
  public class Person
  {
    public string Name { get; }
    public int Age { get; }

    public Person()
    {
      Name = "Unknown";
      Age = 0;
      Console.WriteLine("Parameterless constructor called!");
    }

    public Person(string name, int age)
    {
      Name = name;
      Age = age;
      Console.WriteLine($"Parameterized constructor called: {name}, {age}");
    }

    public override string ToString() => $"{Name} ({Age})";
  }
  public class ActivatorExample
  {
    public static void Run()
    {
      Console.WriteLine("=== Activator + Reflection ===\n");

      var person1 = (Person)Activator.CreateInstance(typeof(Person))!;
      Console.WriteLine($"Person1: {person1}");
    }
  }
}
