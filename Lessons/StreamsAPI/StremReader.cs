public class SR
{
    public static void Run()
    {
        using (StreamReader sr = new StreamReader("test.txt"))
        {
            string line;

            while ((line = sr.ReadLine()!) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}

// INFO: ! = ignore null warning
// INFO: ?. = null-safe call
