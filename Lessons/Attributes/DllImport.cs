using System.Runtime.InteropServices;

class DllImportExample
{
  [DllImport("libc")]
  public static extern int printf(string format, string message);

  public static void Run()
  {
    printf("Hello from %s\n", "native Linux C library!");
    Native.hello();
    int result = Native.add(5, 7);
    Console.WriteLine($"Result from C: {result}");
  }
}

class Native
{
  [DllImport("libnative.so")]
  public static extern int add(int a, int b);

  [DllImport("libnative.so")]
  public static extern void hello();
}
