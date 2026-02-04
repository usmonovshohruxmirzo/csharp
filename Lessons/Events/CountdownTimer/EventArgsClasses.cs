namespace Events
{
  public class StartedEventArgs : EventArgs
  {
    public string TimerName { get; }
    public int Ticks { get; }

    public StartedEventArgs(string timerName, int ticks)
    {
      TimerName = timerName;
      Ticks = ticks;
    }
  }

  public class TickEventArgs : EventArgs
  {
    public string TimerName { get; }
    public int RemainingTicks { get; }

    public TickEventArgs(string timerName, int remainingTicks)
    {
      TimerName = timerName;
      RemainingTicks = remainingTicks;
    }
  }

  public class StoppedEventArgs : EventArgs
  {
    public string TimerName { get; }

    public StoppedEventArgs(string timerName)
    {
      TimerName = timerName;
    }
  }
}
