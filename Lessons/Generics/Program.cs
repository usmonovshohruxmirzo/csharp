using System.Collections;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList list = new ArrayList();
            list.Add(42);
            int num = (int)list[0]!;


            List<int> numbers = new List<int>();
            numbers.Add(42);
            int num2 = numbers[0];

            Console.WriteLine("{0}, {1}", num, num2);

            Box<string> box = new Box<string> { Value = "Hello" };
            Console.WriteLine(box.Value);

            Box<int> boxNum = new Box<int> { Value = 123 };
            Console.WriteLine(box.Value);

            Utils.Print<string>("Hello");
            Utils.Print<int>(123);

            IRepository<int> repo = new Repository<int>();
            repo.Add(1);

            Pair<string, int> person = new Pair<string, int>("Alex", 123);
            Console.WriteLine(person.First + " " + person.Second);
        }
    }
}

public class Box<T>
{
    public required T Value { get; set; }
}

public class Repository<T> : IRepository<T>
{
    private List<T> items = new();
    public void Add(T item) => items.Add(item);
    public IEnumerable<T> GetAll() => items;
}

public class Utils
{
    public static void Print<T>(T value)
    {
        Console.WriteLine(value);
    }
}


// 5. Type Constraints (where keyword)
public class Factory<T> where T : new()
{
    public T CreateInstance() => new T();
}

// 6. Generic Interfaces
public interface IRepository<T>
{
  void Add(T item);
  IEnumerable<T> GetAll();
}

// 7. Multiple Type Parameters

public class Pair<T1, T2>
{
  public T1? First { get; }
  public T2? Second { get; }

  public Pair(T1 first, T2 second)
  {
    First = first;
    Second = second;
  }
}
// 8. Covariance and Contravariance (Advanced)

// 9. Generic Delegates

// 10. Generic Structs

// 11. Nested Generics

// 12. Default Value for Generics

// 13. Reflection with Generics

// 14. Generic Inheritance

// 15. Common .NET Generic Types

// 16. Generic Constraints in Hierarchy

// 17. Performance and Type Erasure

// 19. Generic Extension Methods

// 20. Advanced Tips
