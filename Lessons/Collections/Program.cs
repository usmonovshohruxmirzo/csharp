using System.Collections;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // NonGenericCollections.Run();
            GenericCollections.Run();
        }
    }
}

class NonGenericCollections
{

    public static void Run()
    {

        // INFO: Pros: Dynamic resizing
        // INFO: Cons: Boxing/unboxing, type safety issues

        Console.WriteLine("\nArrayList\n");

        ArrayList list = new ArrayList();
        list.Add(10);
        list.Add("Hello");
        list.Add(3.14);
        list.Add(true);

        foreach (var item in list)
        {
            Console.WriteLine(item);

        }
        int x = (int)list[0]!;
        Console.WriteLine(x);

        // INFO: Pros: Fast key lookup
        // INFO: Cons: No type safety

        Console.WriteLine("\nHashtable\n");

        Hashtable table = new Hashtable();
        table["id"] = 101;
        table["name"] = "Shohrux";
        table["age"] = 18;

        Console.WriteLine(table["name"]);
    }
}

class GenericCollections
{
    public static void Run()
    {
        Console.WriteLine("\n ============== List ============== \n");

        List<string> cars = new List<string> { "Tesla", "Ferrari", "Audi" };

        // INFO: ADD ELEMENTS
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("ADD ELEMENTS");
        cars.Add("Honda");
        cars.AddRange(new List<string> { "Ford", "Toyota" });
        Display(cars);

        // INFO: INSERT ELEMENTS
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("INSERT ELEMENTS");
        cars.Insert(2, "Nissan");
        cars.InsertRange(1, new List<string> { "Volvo", "Mazda" });
        Console.WriteLine();
        Display(cars);

        // INFO: REMOVE ELEMENTS
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("REMOVE ELEMENTS");
        cars.Remove("Toyota");
        cars.RemoveAt(0);
        Display(cars);
        cars.RemoveRange(2, 4);
        Console.WriteLine();
        Display(cars);

        // INFO: SEARCHING
        Console.WriteLine();
        Console.WriteLine($"\nContains Toyota? {cars.Contains("Volvo")}");
        Console.WriteLine($"Index of Nissan: {cars.IndexOf("Mazda")}");
        Console.WriteLine($"Last Index of Toyota: {cars.LastIndexOf("Ford")}");

        // INFO: SORTING & REVERSING
        List<int> nums = new List<int> { 2, 3, 4, 8, 6, 9, 8, 1 };
        nums.Sort();
        Console.Write("Sorted: ");
        Display<int>(nums);
        Console.WriteLine();
        Console.Write("Reversed: ");
        nums.Reverse();
        Display(nums);

        // INFO: CAPACITY & COUNT
        Console.WriteLine($"\nCount: {cars.Count}");
        Console.WriteLine($"Capacity: {cars.Capacity}");

        // INFO: CLEAR LIST
        cars.Clear();
        Console.WriteLine($"\nAfter Clear: Count = {cars.Count}");

        // INFO: CAPACITY

        List<string> cars2 = new List<string>(100);
        Console.WriteLine($"Initial Capacity: {cars.Capacity}");
        Console.WriteLine($"Initial Count: {cars.Count}");
        cars2.Add("Honda");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        cars2.Add("Toyota");
        Console.WriteLine($"After Adding 2: Count = {cars2.Count}, Capacity = {cars2.Capacity}");
        
        Console.WriteLine(new string('A', 10));
    }

     public static void Display<T>(List<T> list)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(string.Join(", ", list));
        Console.ResetColor();
    }

     public static void Display(List<string> list)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(string.Join(", ", list));
        Console.ResetColor();
    }

    public static void CountElements(List<string> cars)
    {
        Console.WriteLine(cars.Count());
    }
}
