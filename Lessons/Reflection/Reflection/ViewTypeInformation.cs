using System;
using System.Reflection;

namespace ViewTypeInformation
{
    public class ViewTypeInformation
    {
        public static void View()
        {
            Type t = typeof(System.String);
            Console.WriteLine($"Listing all the public constructors of the {t} type");
            // Constructors.
            ConstructorInfo[] ci = t.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("//Constructors");
            PrintMembers(ci);
        }

        public static void MyMethodInfo()
        {
            Console.WriteLine("Reflection.MethodInfo");
            // Gets and displays the Type.
            Type myType = Type.GetType("System.Reflection.FieldInfo");
            // Specifies the member for which you want type information.
            MethodInfo myMethodInfo = myType.GetMethod("GetValue");
            Console.WriteLine(myType.FullName + "." + myMethodInfo.Name);
            // Gets and displays the MemberType property.
            MemberTypes myMemberTypes = myMethodInfo.MemberType;
            if (MemberTypes.Constructor == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type All");
            }
            else if (MemberTypes.Custom == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Custom");
            }
            else if (MemberTypes.Event == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Event");
            }
            else if (MemberTypes.Field == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Field");
            }
            else if (MemberTypes.Method == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Method");
            }
            else if (MemberTypes.Property == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type Property");
            }
            else if (MemberTypes.TypeInfo == myMemberTypes)
            {
                Console.WriteLine("MemberType is of type TypeInfo");
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
