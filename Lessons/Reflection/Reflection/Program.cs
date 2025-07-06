using System;
using System.Reflection;
using ViewTypeInformation;
// ----------------------------------------------------------
// Custom attribute definition
// ----------------------------------------------------------

// AttributeUsage controls where this attribute can be used
// (here: on classes and methods only)
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public class MyCustomAttribute : Attribute
{
    // This property will hold a description text
    public string Description { get; }

    // Constructor to set the description value
    public MyCustomAttribute(string description)
    {
        Description = description;
    }
}

// ----------------------------------------------------------
// Class to be inspected and manipulated using Reflection
// ----------------------------------------------------------
[MyCustomAttribute("This is a test class with custom attribute")]
public class Person
{
    // Private field, normally inaccessible
    private int id = 1;

    // Public properties
    public string Name { get; set; }
    public int Age { get; set; }

    // Default constructor: sets default property values
    public Person()
    {
        Name = "Default";
        Age = 0;
    }

    // Overloaded constructor: allows custom initialization
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Public method to greet, with an attribute attached
    [MyCustomAttribute("This method prints a greeting")]
    public void Greet(string message)
    {
        Console.WriteLine($"Hello {Name}, message: {message}");
    }

    // Private method, hidden from normal external calls
    private void Secret()
    {
        Console.WriteLine("This is a private secret method!");
    }
}

namespace MyNamespace 
{ 
    public class MyClass { } 
}

class Program
{
    static void Main(string[] args)
    {
        // ========== View type information
        Assembly a = typeof(object).Module.Assembly;
        Console.WriteLine(a);

        ViewTypeInformation.ViewTypeInformation.View();
        ViewTypeInformation.ViewTypeInformation.MyMethodInfo();
        
        //
        
        var type = typeof(MyNamespace.MyClass);
        string info = $"{type.Namespace}, {type.Name}, {type.FullName}, {type.BaseType.Name}";
        Console.WriteLine(info);

        // --------------------------------------------------
        // 1️⃣ Get Type metadata for Person class
        // --------------------------------------------------
        Type personType = typeof(Person);  // gets the Type object at compile-time
        Console.WriteLine("Type Name: " + personType.FullName);

        // --------------------------------------------------
        // 2️⃣ List constructors
        // --------------------------------------------------
        Console.WriteLine("\nConstructors:");
        ConstructorInfo[] constructors = personType.GetConstructors(); // only public constructors
        foreach (var ctor in constructors)
        {
            Console.WriteLine(ctor); // prints constructor signatures
        }

        // --------------------------------------------------
        // 3️⃣ List public properties
        // --------------------------------------------------
        Console.WriteLine("\nProperties:");
        PropertyInfo[] props = personType.GetProperties();
        foreach (var prop in props)
        {
            // print property type and name
            Console.WriteLine($"{prop.PropertyType.Name} {prop.Name}");
        }

        // --------------------------------------------------
        // 4️⃣ List public methods
        // --------------------------------------------------
        Console.WriteLine("\nMethods:");
        MethodInfo[] methods = personType.GetMethods();
        foreach (var method in methods)
        {
            // print method names (includes methods from System.Object, like ToString)
            Console.WriteLine(method.Name);
        }

        // --------------------------------------------------
        // 5️⃣ List all fields, including private
        // --------------------------------------------------
        Console.WriteLine("\nFields:");
        FieldInfo[] fields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var field in fields)
        {
            // print field type and name
            Console.WriteLine($"{field.FieldType.Name} {field.Name}");
        }

        // --------------------------------------------------
        // 6️⃣ Create instance using default constructor
        // --------------------------------------------------
        object personInstance = Activator.CreateInstance(personType);
        Console.WriteLine("\nCreated instance using default constructor.");

        // --------------------------------------------------
        // 7️⃣ Dynamically set public properties
        // --------------------------------------------------
        PropertyInfo nameProp = personType.GetProperty("Name");
        nameProp.SetValue(personInstance, "Alice"); // set Name to Alice

        PropertyInfo ageProp = personType.GetProperty("Age");
        ageProp.SetValue(personInstance, 25); // set Age to 25

        // Read properties back
        Console.WriteLine($"Name set to: {nameProp.GetValue(personInstance)}");
        Console.WriteLine($"Age set to: {ageProp.GetValue(personInstance)}");

        // --------------------------------------------------
        // 8️⃣ Access and modify private field 'id'
        // --------------------------------------------------
        FieldInfo idField = personType.GetField("id", BindingFlags.NonPublic | BindingFlags.Instance);
        idField.SetValue(personInstance, 99); // set id to 99
        Console.WriteLine($"Private field 'id' set to: {idField.GetValue(personInstance)}");

        // --------------------------------------------------
        // 9️⃣ Call public method Greet
        // --------------------------------------------------
        MethodInfo greetMethod = personType.GetMethod("Greet");
        greetMethod.Invoke(personInstance, new object[] { "Welcome to Reflection!" }); // pass message parameter

        // --------------------------------------------------
        // 🔟 Call private method Secret
        // --------------------------------------------------
        MethodInfo secretMethod = personType.GetMethod("Secret", BindingFlags.NonPublic | BindingFlags.Instance);
        secretMethod.Invoke(personInstance, null); // no parameters

        // --------------------------------------------------
        // 1️⃣1️⃣ Create instance with overloaded constructor
        // --------------------------------------------------
        object personWithParams = Activator.CreateInstance(personType, new object[] { "Bob", 30 });
        // Read properties of the new instance
        Console.WriteLine($"\nCreated instance with parameters: Name = {personType.GetProperty("Name").GetValue(personWithParams)}, Age = {personType.GetProperty("Age").GetValue(personWithParams)}");

        // --------------------------------------------------
        // 1️⃣2️⃣ Read class-level custom attribute
        // --------------------------------------------------
        Console.WriteLine("\nClass-level Attributes:");
        object[] classAttrs = personType.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach (MyCustomAttribute attr in classAttrs)
        {
            // print description of custom attribute
            Console.WriteLine($"Class attribute description: {attr.Description}");
        }
        
        // --------------------------------------------------
        // 1️⃣3️⃣ Read method-level custom attribute
        // --------------------------------------------------
        Console.WriteLine("\nMethod-level Attributes:");
        MethodInfo greet = personType.GetMethod("Greet");
        object[] methodAttrs = greet.GetCustomAttributes(typeof(MyCustomAttribute), false);
        foreach (MyCustomAttribute attr in methodAttrs)
        {
            // print description from the attribute on Greet method
            Console.WriteLine($"Method attribute description: {attr.Description}");
        }
    }
}
