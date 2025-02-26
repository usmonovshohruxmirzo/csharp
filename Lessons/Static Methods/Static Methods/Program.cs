using System;
using System.Threading.Tasks;
using System.Linq;
using System.Text.RegularExpressions;
class Program
{
    static void Main(string[] args)
    {
        String name = "CS";
        sayHello(name, 198);
        Console.WriteLine("Result " + Sum(10, 20));

        //double x;
        //double y;
        //double result;

        //Console.WriteLine("Enter number 1: ");
        //x = Convert.ToDouble(Console.ReadLine());

        //Console.WriteLine("Enter number 1: ");
        //y = Convert.ToDouble(Console.ReadLine());

        //result = Multiply(x, y);

        //Console.WriteLine(result);

        //Console.ReadKey();  // Waits for a key press

        BaseClass obj = new BaseClass();
        obj.Show();

        int mathHelperResult = MathHelper.Square(10);
        Console.WriteLine(mathHelperResult);

        Greet(); // Hello Guest, Age: 18
        Greet("Alice"); // Hello Alice, Age: 18
        Greet(age: 25, name: "Bob");

        int result = Task.Run(() => FetchDataAsync()).Result; // Blocking call
        Console.WriteLine($"Result: {result}");

        Console.WriteLine("hello".ToUpperCase());
        Console.WriteLine("hello world".ToKebabCase());

        // Expression-bodied Members
        int Square(int x) => x * x; // Reduces code verbosity.
        Console.WriteLine(Square(4));
    }
    static void sayHello(String name, int age)
    {
        Console.WriteLine("Hello " + name);
        Console.WriteLine("You are " + age);
    }

    static int Sum(int a, int b)
    {
        return a + b;
    }

    static double Multiply(double x, double y)
    {
        double c = x * y;
        return c;
    }

    // Method Overloading
    // public = full access (any class can use it).
    public int Add(int a, int b) { return a + b; }
    public double Add(double a, double b) { return a + b; }
    public int Add(int a, int b, int c) { return a + b + c; }

    //Optional and Named Parameters
    // static: Class-level(call without an instance).
    // public: Instance-level(needs an object).
    static void Greet(string name = "Guest", int age = 18)
    {
        Console.WriteLine($"Hello {name}, Age: {age}");
    }

    //Async and Await (Asynchronous Methods)
    static async Task<int> FetchDataAsync()
    {
        await Task.Delay(2000); // Simulating delay
        return 42;
    }
}

public class BaseClass
{
    // virtual allows a method or property to be overridden in a derived class.
    public virtual void Show()
    {
        Console.WriteLine("Base Class Method");
    }
}

public class DerivedClass : BaseClass
{
    // override replaces a virtual method from the base class in a derived class
    public override void Show()
    {
        Console.WriteLine("Derived Class Method");
    }
}

//Static Methods
//Static methods belong to the class, not an instance.
public static class MathHelper
{
    public static int Square(int num)
    {
        return num * num;
    }
}

//Extension Methods
public static class StringExtensions
{
    public static string ToUpperCase(this string str) // this keyword makes it an extension method.
    {
        return str.ToUpper();
    }

    public static string ToKebabCase(this string str)
    {
        return Regex.Replace(str, @"\s+", "-").ToLower();
    }
}

//Console.WriteLine("hello".ToUpperCase()); // Output: HELLO

// Iterators


//Access Modifiers(Visibility Control)
class Example
{
    public void PublicMethod() { }  // Accessible anywhere
    private void PrivateMethod() { } // Accessible only in this class
    protected void ProtectedMethod() { } // Accessible in derived classes
    internal void InternalMethod() { } // Accessible in the same assembly
}
