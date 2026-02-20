namespace MultiThreading
{
  class Program
  {
    static readonly object locker = new();
    static int counter = 0;
    static void Main(string[] args)
    {
      Increment();
      Console.WriteLine(counter);
    }

    static void Increment()
    {
      for (int i = 0; i < 100000; i++)
      {
        lock (locker)
        {
          counter++;
        }
      }
    }
  }
}
