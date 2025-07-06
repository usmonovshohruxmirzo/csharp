namespace GenericTypes;

public class GenericTypes
{
    public static void Run()
    {
        Type openList = typeof(List<>);
        Console.WriteLine($"IsGenericType: {openList.IsGenericType}");
        Console.WriteLine($"IsGenericTypeDefinition: {openList.IsGenericTypeDefinition}");

        Type closedList = openList.MakeGenericType(typeof(string));
        Console.WriteLine($"\nClosed type: {closedList}");
        Console.WriteLine($"ContainsGenericParameters: {closedList.ContainsGenericParameters}");

        Type def = closedList.GetGenericTypeDefinition();
        Console.WriteLine($"Generic type definition: {def}");

        Type[] args = closedList.GetGenericArguments();
        Console.WriteLine("\nGeneric arguments:");
        foreach (var arg in args)
        {
            Console.WriteLine($"  {arg} (IsGenericParameter: {arg.IsGenericParameter})");
        }
    }

    public class Demo<T>
    {
        public void PrintType<U>()
        {
            Console.WriteLine($"T: {typeof(T)}, U: {typeof(U)}");    
        }
    }

    public class Containered<T> where T : class, new()
    {
        // T must be a reference type (class) and must have a parameterless constructor (new())
    }
}