using System.Diagnostics;

class Logger
{
    [Conditional("DEBUG")]
    public static void Debug(string msg)
        => Console.WriteLine("[DEBUG] " + msg);
}
