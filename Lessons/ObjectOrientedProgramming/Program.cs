using ObjectOrientedProgramming.Concepts;
using System.Diagnostics.CodeAnalysis;

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


            Person person = new Person() { FirstName = "John", LastName = "Doe", ID = 1, Job = "Software Engineer" };
            Person person1 = new Person() { FirstName = "John", LastName = "Doe", ID = 1, Job = "Software Engineer" };
            Person person3 = new Person("John", "Doe", 2, "Doctor");

            // Classes.RunClasses();
            // PrinciplesOfOOP.RunPrinciplesOfOOP();
            // Inheritance.RunInheritance();
            // AbstractClasses.RunAbstractClasses();
        }
    }


    public class Person
    {
        public Person() { }

        [SetsRequiredMembers]
        public Person(string fname, string lname, int id, string job)
        {
            ID = id;
            FirstName = fname;
            LastName = lname;
            Job = job;
        }

        public required int ID { get; init; }
        public required string? FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Job { get; set; }

        public override string ToString() => $"{FirstName} {LastName}, ID: {ID}, JOB: {Job}";
    }
}
