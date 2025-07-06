using System;
using System.Reflection;

namespace ViewTypeInformation
{
    public class ViewTypeInformation
    {
        public static void View()
        {
           // Specifies the class.
            Type t = typeof(System.IO.BufferedStream);
            Console.WriteLine($"Listing all the members (public and non public) of the {t} type");

            // Lists static fields first.
            FieldInfo[] fi = t.GetFields(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Fields");
            PrintMembers(fi);

            // Static properties.
            PropertyInfo[] pi = t.GetProperties(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Properties");
            PrintMembers(pi);

            // Static events.
            EventInfo[] ei = t.GetEvents(BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Events");
            PrintMembers(ei);

            // Static methods.
            MethodInfo[] mi = t.GetMethods (BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Static Methods");
            PrintMembers(mi);

            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Instance |
                BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("// Constructors");
            PrintMembers(ci);

            // Instance fields.
            fi = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Fields");
            PrintMembers(fi);

            // Instance properties.
            pi = t.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine ("// Instance Properties");
            PrintMembers(pi);

            // Instance events.
            ei = t.GetEvents(BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public);
            Console.WriteLine("// Instance Events");
            PrintMembers(ei);

            // Instance methods.
            mi = t.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic
                | BindingFlags.Public);
            Console.WriteLine("// Instance Methods");
            PrintMembers(mi);

            Console.WriteLine("\r\nPress ENTER to exit.");
            Console.Read();
        }

        public static void MyMethodInfo()
        {
            Console.WriteLine("Reflection.MemberInfo");

            Type myType = typeof(DemoClass);
            
            MemberInfo[] members = new MemberInfo[]
            {
                myType.GetConstructor(Type.EmptyTypes),
                myType.GetEvent("MyEvent"),
                myType.GetField("MyField"),
                myType.GetMethod("MyMethod"),
                myType.GetProperty("MyProperty"),
                myType.GetTypeInfo()
            };
            

            foreach (var member in members)
            {
                ArgumentNullException.ThrowIfNull(member);

                MemberTypes myMemberTypes = member.MemberType;
                Console.WriteLine(myType.FullName + "." + member.Name);

                switch (myMemberTypes)
                {
                    case MemberTypes.Constructor:
                        Console.WriteLine("MemberType is of type Constructor");
                        break;
                    case MemberTypes.Custom:
                        Console.WriteLine("MemberType is of type Custom");
                        break;
                    case MemberTypes.Event:
                        Console.WriteLine("MemberType is of type Event");
                        break;
                    case MemberTypes.Field:
                        Console.WriteLine("MemberType is of type Field");
                        break;
                    case MemberTypes.Method:
                        Console.WriteLine("MemberType is of type Method");
                        break;
                    case MemberTypes.Property:
                        Console.WriteLine("MemberType is of type Property");
                        break;
                    case MemberTypes.TypeInfo:
                        Console.WriteLine("MemberType is of type TypeInfo");
                        break;
                    default:
                        Console.WriteLine("MemberType is of unknown type");
                        break;
                }
                Console.WriteLine();
            }
        }
        
        public static void PrintMembers (MemberInfo [] ms)
        {
            foreach (MemberInfo m in ms)
            {
                Console.WriteLine ("{0}{1}", "     ", m);
            }
            Console.WriteLine();
        }
    }
}

class DemoClass
{
    public event EventHandler MyEvent;
    public int MyField;
    public void MyMethod() {}
    public int MyProperty { get; set; }
    public DemoClass() {}
}