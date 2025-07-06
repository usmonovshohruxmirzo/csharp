using System;
using System.Collections.Generic;
using System.Reflection;

namespace GenericTypes
{

    public class GenericTypes
    {
        public static void Run()
        {
            Type listDef = typeof(List<>);
            Type[] typeParams1 = listDef.GetGenericArguments();
            Console.WriteLine(typeParams1[0].Name);
            Console.WriteLine(typeParams1[0].IsGenericTypeDefinition);
            
            // 1️⃣ Open generic type: List<>
            Type openList = typeof(List<>);
            Console.WriteLine($"IsGenericType: {openList.IsGenericType}");
            Console.WriteLine($"IsGenericTypeDefinition: {openList.IsGenericTypeDefinition}");

            // 2️⃣ Closed generic type: List<string>
            Type closedList = openList.MakeGenericType(typeof(string));
            Console.WriteLine($"\nClosed type: {closedList}");
            Console.WriteLine($"ContainsGenericParameters: {closedList.ContainsGenericParameters}");

            // 3️⃣ Get generic type definition
            Type def = closedList.GetGenericTypeDefinition();
            Console.WriteLine($"Generic type definition: {def}");

            // 4️⃣ Get generic arguments
            Type[] args = closedList.GetGenericArguments();
            Console.WriteLine("\nGeneric arguments:");
            foreach (var arg in args)
            {
                Console.WriteLine($"  {arg} (IsGenericParameter: {arg.IsGenericParameter})");
            }

            // 5️⃣ Generic method reflection
            MethodInfo mi = typeof(Demo<>).GetMethod("PrintType");
            Console.WriteLine($"\nIsGenericMethod: {mi.IsGenericMethod}");
            Console.WriteLine($"IsGenericMethodDefinition: {mi.IsGenericMethodDefinition}");

            // Create a closed generic method
            MethodInfo closedMi = mi.MakeGenericMethod(typeof(int));
            Console.WriteLine($"Closed generic method: {closedMi}");

            // 6️⃣ Check type parameter details
            Type[] typeParams = typeof(Demo<>).GetGenericArguments();
            Console.WriteLine("\nType parameters of Demo<>:");
            foreach (var p in typeParams)
            {
                Console.WriteLine($"  Name: {p.Name}");
                Console.WriteLine($"  DeclaringType: {p.DeclaringType}");
                Console.WriteLine($"  IsGenericParameter: {p.IsGenericParameter}");
                Console.WriteLine($"  Position: {p.GenericParameterPosition}");
                Console.WriteLine();
            }

            // 7️⃣ Constraints example
            Type[] constrParams = typeof(Constrained<>).GetGenericArguments();
            Type constrainedParam = constrParams[0];
            Console.WriteLine("Constraints of T in Constrained<>:");
            var constraints = constrainedParam.GetGenericParameterConstraints();
            foreach (var c in constraints)
            {
                Console.WriteLine($"  Constraint: {c}");
            }

            var attrs = constrainedParam.GenericParameterAttributes;
            Console.WriteLine($"GenericParameterAttributes: {attrs}");
        }
    }

    // Demo generic class with method
    public class Demo<T>
    {
        public void PrintType<U>()
        {
            Console.WriteLine($"T: {typeof(T)}, U: {typeof(U)}");
        }
    }

    // Example generic class with constraints
    public class Constrained<T> where T : class, new() {}
}
