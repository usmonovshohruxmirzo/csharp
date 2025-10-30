using System.Collections;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // NonGenericCollections.Run();
            // ListClass.Run();

            // TodoList<string> todoList = new TodoList<string>();
            // todoList.Add("Hello");
            // todoList.Add("Hello 2");
            // todoList.Add("Hello 3");
            // todoList.Add("Hello 4");
            // todoList.Remove("Hello");
            // todoList.Update("Hello", "Updated");
            // todoList.Display();
            //
            //

            // QueueClass.Run();
            // StackClass.Run();
            DictionaryClass.Run();
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

class ListClass
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
        // Growth Pattern: Usually, the new capacity is double the old one (exponential growth), though it can differ slightly between .NET versions.

        List<string> cars2 = new List<string>(2);
        Console.WriteLine($"Initial Capacity: {cars.Capacity}");
        Console.WriteLine($"Initial Count: {cars.Count}");
        cars2.Add("Honda");
        cars2.Add("Toyota");
        Console.WriteLine($"After Adding 2: Count = {cars2.Count}, Capacity = {cars2.Capacity}");

        Console.WriteLine(new string('A', 10));

        List<int> numbers = new List<int>();

        for (int i = 1; i <= 20; i++)
        {
            numbers.Add(i);
            Console.WriteLine($"Count: {numbers.Count}, Capacity: {numbers.Capacity}");
        }
        numbers.Capacity = 1000;
        Console.WriteLine(numbers.Capacity);
        numbers.TrimExcess();
        Console.WriteLine(numbers.Capacity);


        // Cast<T>() is a LINQ method that converts all elements in a collection to a specific type.
        Console.WriteLine("========== Cast");
        ArrayList castNums = new ArrayList { 1, 2, 3, 4, 5, 6 };
        var casted = castNums.Cast<int>();
        Display<int>(casted.ToList());
        Console.WriteLine();
        Console.WriteLine(castNums[0]?.GetType());
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

class QueueClass // FIFO (First In, First Out)
{
    /*
        | Operation | Time Complexity |
        | --------- | --------------- |
        | Enqueue   | O(1) amortized  |
        | Dequeue   | O(1)            |
        | Peek      | O(1)            |
        | Contains  | O(n)            |
        | ToArray   | O(n)            |
  */
    public static void Run()
    {
        Queue<string> cars = new Queue<string>();
        cars.Enqueue("BMW");
        cars.Enqueue("Audi");
        cars.Enqueue("Tesla");

        Console.Write(string.Join(" -> ", cars));

        Console.WriteLine();
        if (cars.Contains("Tesla")) Console.WriteLine("Tesla is in the queue");

        Console.WriteLine(cars.GetType());

        string[] carArray = cars.ToArray();
        Console.WriteLine(carArray.GetType());

        Console.WriteLine(cars.Peek());

        cars.Dequeue();

        Console.WriteLine(cars.Peek());
        Console.WriteLine(cars.Count);

        cars.Clear();

        // cars.Dequeue(); // Throws an error

        // safer version of Dequeue
        if (cars.TryDequeue(out string? car)) Console.WriteLine($"Removed: {car}");
        else Console.WriteLine("Queue is empty");

        if (cars.TryPeek(out string? peekCar)) Console.WriteLine($"Next: {peekCar}");
        else Console.WriteLine("Queue is empty");

        // INFO: EnsureCapacity
        Queue<int> q = new Queue<int>();
        Console.WriteLine("Initial queue count: " + q.Count);

        for (int i = 1; i <= 10; i++)
        {
            q.Enqueue(i);
        }
        Console.WriteLine("Count after adding 10 items: " + q.Count);

        q.EnsureCapacity(100);
        Console.WriteLine("Ensured capacity for 100 items (internal, no resize needed until 100 added)");

        for (int i = 11; i <= 100; i++)
        {
            q.Enqueue(i);
        }
        Console.WriteLine("Count after adding 100 items: " + q.Count);

        q.Enqueue(101);
        Console.WriteLine("Added 101st item, count: " + q.Count);
    }
}

public class StackClass // LIFO (Last In, First Out)
{
    public static void Run()
    {
        Stack<int> stack = new Stack<int>();

        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        stack.Pop();

        foreach (var item in stack)
        {
            Console.WriteLine(item);
        }

    }
}

public class DictionaryClass
{
    public static void Run()
    {
        Dictionary<int, string> users = new Dictionary<int, string>()
        {
            { 1, "Alice" },
            { 2, "Bob" },
        };

        users[3] = "Charlie";
        users.Add(4, "David");

        if (!users.TryAdd(2, "Bobby"))
        {
            Console.WriteLine("Key 2 already exists, TryAdd failed.\n");
        }

        Display(users);

        Console.WriteLine($"Contains key 2: {users.ContainsKey(2)}");
        Console.WriteLine($"Contains value 'Alice': {users.ContainsValue("Alice")}\n");

        Console.WriteLine($"Total users: {users.Count}\n");

        if (users.TryGetValue(3, out string? name))
        {
            Console.WriteLine($"User with key 3: {name}\n");
        }

        Console.WriteLine("Values:");
        foreach (var value in users.Values)
            Console.WriteLine(value);
        Console.WriteLine();

        Console.WriteLine("Keys:");
        foreach (var key in users.Keys)
            Console.WriteLine(key);
        Console.WriteLine();

        users.Remove(4);
        Console.WriteLine("After removing key 4:");
        Display(users);

        if (users.Remove(3, out string? removedValue))
            Console.WriteLine($"Removed value: {removedValue}\n");

        users.EnsureCapacity(100);

        for (int i = 5; i <= 10; i++)
            users[i] = $"User{i}";

        Console.WriteLine("After bulk insert:");
        Display(users);

        KeyValuePair<int, string>[] pairs = new KeyValuePair<int, string>[users.Count];
        ((ICollection<KeyValuePair<int, string>>)users).CopyTo(pairs, 0);

        Console.WriteLine("Copied to array:");
        foreach (var kv in pairs)
            Console.WriteLine($"{kv.Key}: {kv.Value}");
        Console.WriteLine();

        users.Clear();
        Console.WriteLine($"After Clear(): Count = {users.Count}");
    }

    public static void Display(Dictionary<int, string> users)
    {
        Console.WriteLine("Dictionary contents:");
        foreach (var kvp in users)
            Console.WriteLine($"ID: {kvp.Key}, Name: {kvp.Value}");
        Console.WriteLine();
    }
}

class TodoList<T>
{
    private List<T> todos = new List<T>();

    public TodoList()
    {
    }

    public void Display()
    {
        foreach (var item in todos)
        {
            Console.WriteLine("ID: {0}, TODO: {1}", todos.IndexOf(item), item);
        }
    }

    public void Add(T value)
    {
        todos.Add(value);
    }

    public void Remove(T value)
    {
        todos.Remove(value);
    }

    public void Clear()
    {
        todos.Clear();
    }

    public void Update(T old, T @new)
    {

        // WARN: IF list all elements are same e.g "Hello" IndexOf always reutns 0
        todos[todos.IndexOf(old)] = @new;
    }
}
