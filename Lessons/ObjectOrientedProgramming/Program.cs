using ObjectOrientedProgramming.Concepts;

namespace ObjectOrientedProgramming
{
    public class Program
    {
        static void Main()
        {
            // Anonymous types
            var myObj = new
            {
                Name = "Alex",
                Age = 25,
                Address = new
                {
                    Street = "123 Grow St",
                    City = "Los Santos",
                }
            };
            Console.WriteLine(myObj);
            // Anonymous types are read-only and cannto be modified
            // myObj.Name = "Hello";

            // To change a value, use non-destructive mutation and "with" clause
            var myObj2 = myObj with { Name = "Jack" };
            Console.WriteLine(myObj2);

            Console.WriteLine($"{myObj.GetType().GetProperty("Name") != null}");
            Console.WriteLine($"{myObj.GetType().GetProperty("Job") != null}");

            // Classes.RunClasses();
            // PrinciplesOfOOP.RunPrinciplesOfOOP();
            // Inheritance.RunInheritance();
            // AbstractClasses.RunAbstractClasses();
        }
    }

}
