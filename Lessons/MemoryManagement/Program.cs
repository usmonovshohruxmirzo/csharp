namespace MemoryManagement
{
    // INFO: In C#, memory management is primarily handled by the Common Language Runtime (CLR).
    // As a developer, you don’t need to manually allocate or release memory, since the runtime manages it for you.

    class Program
    {
        static void Main(string[] args)
        {
            // CreateStudent();
            // GarbageCollector.Run();
            FileHandler fh = new FileHandler("test.txt");
            fh.ReadFile();
            fh.Dispose();

            using (var buf = new NativeBuffer(1024))
            {
                Console.WriteLine("Using buffer");
            }
            Console.WriteLine("End of Main");
        }

        static void Calculate()
        {
            int a = 10; // stored in stack
            int b = 50; // stored in stack
            int result = a + b; // stored in stack
        }

        static void CreateStudent()
        {
            Student student = new Student(); // reference `student` on stack, object on heap
            student.Name = "Alex"; // field stored in heap
            Console.WriteLine(student.Name);
        }
    }

    class Student
    {
        public string? Name;
    }
}
