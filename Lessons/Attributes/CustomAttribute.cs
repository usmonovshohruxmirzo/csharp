[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
class DeveloperAttribute(string name, string level) : Attribute
{
  public string Name { get; set; } = name;
  public string Level { get; set; } = level;
}

[Developer("John", "Expert")]
class Project
{
  [Developer("Alex", "Intermediate")]
  public static void Start() { }

  [Developer("Maria", "Beginner")]
  public static void Test() { }
}
