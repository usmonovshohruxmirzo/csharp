public class Delegates
{
    delegate int Operation(int a, int b);


    public static int Add(int x, int y) => x + y;
    public static int Mul(int x, int y) => x * y;

    static Operation add = Add;
    static Operation mul = Mul;

    // WARN: without Delegates
    static int Calculate(int a, int b, string op)
    {
        if (op == "add") return a + b;
        if (op == "mul") return a * b;
        return 0;
    }

    enum OperationType { Add, Mul }

    static int Calculate2(int a, int b, OperationType op)
    {
        return op switch
        {
            OperationType.Add => a + b,
            OperationType.Mul => a * b,
            _ => 0
        };
    }

    public static void Run()
    {
        Console.WriteLine("Delegates");
        Console.WriteLine(add(10, 10));
        Console.WriteLine(add.Invoke(10, 200));
        Console.WriteLine(mul(10, 10));

        Calculate(3, 4, "add");
        Calculate2(3, 5, OperationType.Add);


        // Func (returns value)
        Func<int, int, int> testfunc = (a, b) => a + b;
        Console.WriteLine(testfunc(100, 200));

        Action<string> log = msg => Console.WriteLine(msg);
        log("Hello");

        Predicate<int> isEven = x => x % 2 == 0;
        isEven(4);
    }
}
