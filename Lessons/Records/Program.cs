namespace Records
{
    public record Employee(string Name, int Age);

    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Employee("John", 25);
            var p2 = new Employee("John", 25);

            Console.WriteLine(p1);
            Console.WriteLine(p2);

            Console.WriteLine(p1 == p2);

            // p1.Age = 30; // Error – property is immutable
            var p3 = p1 with { Age = 100 };
            // INFO: The with expression creates a copy of an existing record with selective modifications, preserving immutability.
            Console.WriteLine(p3);
        }
    }
}
