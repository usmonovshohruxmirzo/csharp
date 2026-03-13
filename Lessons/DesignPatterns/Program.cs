namespace DesignPatterns
{
  class Program
  {
    static void Main(string[] args)
    {
      // FactoryPattern();
      // AbstractFactory();
      // BuilderPattern();
      PrototypePattern();
    }

    static void PrototypePattern()
    {
      Character hero1 = new Character
      {
        Name = "Archer",
        Level = 10,
        Weapon = "Bow"
      };

      Character hero2 = hero1.Clone();
      hero2.Name = "Knight";
      hero2.Weapon = "Sword";

      hero1.ShowCharacter();
      hero2.ShowCharacter();
    }

    static void BuilderPattern()
    {
      IComputerBuilder builder = new GamingPCBuilder();
      Director director = new Director(builder);

      director.BuildGamingPC();
      Computer gamingPC = builder.GetComputer();
      gamingPC.ShowSpecs();

      director.BuildOfficePC();
      Computer officePC = builder.GetComputer();
      officePC.ShowSpecs();
    }

    static void FactoryPattern()
    {
      ShapeFactory factory = new ShapeFactory();

      IShape? shape1 = factory.GetShape("Circle");
      IShape? shape2 = factory.GetShape("Square");

      shape1?.Draw();
      shape2?.Draw();
    }

    static void AbstractFactory()
    {
      IGUIFactory factory;

      // Switch factories based on OS
      string os = "Windows"; // Imagine we detect OS
      factory = os == "Windows" ? new WindowsFactory() : new MacFactory();

      Application app = new(factory);
      app.RenderUI();
    }

    static void SingletonPattern()
    {
      Singleton s1 = Singleton.Instance;
      Singleton s2 = Singleton.Instance;

      s1.ShowMessage();
      s2.ShowMessage();

      if (ReferenceEquals(s1, s2))
        Console.WriteLine("s1 and s2 are the same instance!");
      else
        Console.WriteLine("s1 and s2 are different instances!");
    }
  }
}
