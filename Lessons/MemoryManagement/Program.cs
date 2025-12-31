namespace MemoryManagement
{
    // INFO: In C#, memory management is primarily handled by the Common Language Runtime (CLR).
    // As a developer, you don’t need to manually allocate or release memory, since the runtime manages it for you.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
        }

        static void Calculate()
        {
            int a = 10; // stored in stack
            int b = 50; // stored in stack
            int result = a + b; // stored in stack
        }
    }
}
