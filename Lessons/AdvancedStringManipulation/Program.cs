using System.Text.RegularExpressions;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            RegexClass.Run();
        }
    }
}

public class RegexClass
{
    public static void Run()
    {
        // 1. Dot .  -> any character except newline
        Console.WriteLine(Regex.IsMatch("abc", "a.c")); // True (b matches .)

        Console.WriteLine(Regex.IsMatch("color", "colou?r")); // True (matches both color/colour)
    }

}
