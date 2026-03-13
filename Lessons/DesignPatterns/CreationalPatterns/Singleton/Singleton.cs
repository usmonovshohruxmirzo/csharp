class Singleton
{
  private static Singleton? _instance;

  private Singleton() { }

  public static Singleton Instance
  {
    get
    {
      _instance ??= new Singleton();
      return _instance;
    }
  }

  public void ShowMessage()
  {
    Console.WriteLine("Hello from Singleton!");
  }
}
