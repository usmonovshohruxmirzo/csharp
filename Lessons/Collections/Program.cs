using System.Collections;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            NonGenericCollections.Run();
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
