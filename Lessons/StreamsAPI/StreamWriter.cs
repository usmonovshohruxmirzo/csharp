public class SW
{
    public static void Run()
    {
        using (StreamWriter sw = new StreamWriter("test.txt", true))
        {
            sw.WriteLine("Hello, StreamWriter!");
            sw.WriteLine("Appending new content to file.");
        }

        using (StreamWriter sw = new StreamWriter("numbers.txt", false)) {
          for (int i = 1; i <= 100; i++) {
            sw.WriteLine(i);
          }
        }
    }
}
