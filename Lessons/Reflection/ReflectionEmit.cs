using System.Reflection;
using System.Reflection.Emit;

public class ReflectionEmit
{
  public static void Run()
  {
    // 1️⃣ Assembly yaratish
    AssemblyName assemblyName = new AssemblyName("DynamicAssembly");
    AssemblyBuilder assemblyBuilder =
        AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

    // 2️⃣ Module yaratish
    ModuleBuilder moduleBuilder =
        assemblyBuilder.DefineDynamicModule("MainModule");

    // 3️⃣ Class yaratish
    TypeBuilder typeBuilder =
        moduleBuilder.DefineType("Hello",
        TypeAttributes.Public);

    // 4️⃣ Method yaratish
    MethodBuilder methodBuilder =
        typeBuilder.DefineMethod("SayHello",
        MethodAttributes.Public,
        null,
        null);

    // 5️⃣ IL yozish
    ILGenerator il = methodBuilder.GetILGenerator();
    il.Emit(OpCodes.Ldstr, "Hello from Emit!");
    il.Emit(OpCodes.Call,
        typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) }));
    il.Emit(OpCodes.Ret);

    // 6️⃣ Type yaratishni yakunlash
    Type helloType = typeBuilder.CreateType();

    // 7️⃣ Object yaratish
    object instance = Activator.CreateInstance(helloType);

    // 8️⃣ Methodni chaqirish
    helloType.GetMethod("SayHello").Invoke(instance, null);
  }
  public static void DynamicPerson()
  {
    AssemblyName assemblyName = new AssemblyName("DynamicPerson");
    AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

    ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("PersonModule");

    TypeBuilder typeBuilder -moduleBuilder.DefineType("Person", TypeAttributes.Public);



    PropertyBuilder propertyBuilder = typeBuilder.DefineProperty("Name", PropertyAttributes.Public);


  }
}
