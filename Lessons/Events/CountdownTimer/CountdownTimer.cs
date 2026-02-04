namespace Events
{
  public class CountdownTimer
  {
    public static void Run()
    {
      Timer timer = new("MyTimer", 5);

      timer.Started += (s, e) => Console.WriteLine($"Timer '{e.TimerName}' started with {e.Ticks} ticks.");
      timer.Tick += (s, e) => Console.WriteLine($"Timer '{e.TimerName}' tick: {e.RemainingTicks} remaining.");
      timer.Stopped += (s, e) => Console.WriteLine($"Timer '{e.TimerName}' stopped.");

      timer.Start();
    }
  }
}
