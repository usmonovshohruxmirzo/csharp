public class GarbageCollector
{
    public static void Run()
    {
        GCMaxGeneration();
        GCCollect();
        GCGetTotalMemory();
        GCGetGeneration();
    }

    static void GCCollect()
    {
        for (int i = 0; i < 1000; i++)
        {
            var obj = new object();
        }

        GC.Collect();
        GC.WaitForPendingFinalizers();
        Console.WriteLine("Forced garbage collection completed.");
    }

    static void GCGetTotalMemory()
    {
        long before = GC.GetTotalMemory(false);
        int[] arr = new int[1000];
        long after = GC.GetTotalMemory(false);

        Console.WriteLine($"Memory before: {before}");
        Console.WriteLine($"Memory after: {after}");
    }

    static void GCMaxGeneration()
    {
        Console.WriteLine("The number of generations are: {0}", GC.MaxGeneration);
    }

    static void GCGetGeneration()
    {
        string name = "Alex";
        Console.WriteLine("Generation of name: {0}", GC.GetGeneration(name));
    }
}
