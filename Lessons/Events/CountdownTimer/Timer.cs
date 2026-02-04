namespace Events
{
  public class Timer
  {
    private readonly string timerName;
    private readonly int ticks;

    public event EventHandler<StartedEventArgs>? Started;
    public event EventHandler<TickEventArgs>? Tick;
    public event EventHandler<StoppedEventArgs>? Stopped;

    public Timer(string timerName, int ticks)
    {
      if (string.IsNullOrWhiteSpace(timerName))
      {
        throw new ArgumentException("Timer name cannot be null or empty.", nameof(timerName));
      }

      if (ticks <= 0)
      {
        throw new ArgumentException("Ticks must be greater than 0.", nameof(ticks));
      }

      this.timerName = timerName;
      this.ticks = ticks;
    }

    public void Start()
    {
      OnStarted(new StartedEventArgs(timerName, ticks));

      int remaining = ticks;
      while (remaining > 0)
      {
        Thread.Sleep(1000);
        remaining--;
        OnTick(new TickEventArgs(timerName, remaining));
      }

      OnStopped(new StoppedEventArgs(timerName));
    }

    protected virtual void OnStarted(StartedEventArgs e) => Started?.Invoke(this, e);
    protected virtual void OnTick(TickEventArgs e) => Tick?.Invoke(this, e);
    protected virtual void OnStopped(StoppedEventArgs e) => Stopped?.Invoke(this, e);
  }
}
