public class PersonFactory
{
  public static object Person()
  {
    var person = new Person
    {
      FirstName = "John",
      LastName = "Doe",
      Age = 48,
      Level = "Senior",
      Position = "Backend Software Enginner",
      Location = "USA",
      Organazation = "Google",
      Salary = 100.000
    };

    return person;
  }
}
