namespace ObjectOrientedProgramming.Concepts
{
  public class Inheritance
  {
    public static void RunInheritance()
    {
      Animal a = new Dog();
      a.Speak();
      a.Eat();
      Dog d = new Dog();
      d.Eat();
    }
  }
}

class Animal 
{
  public virtual void Speak() => Console.WriteLine("Animal speaks");
  public void Eat() => Console.WriteLine("Animal eats");
}

class Dog : Animal
{
  public override void Speak() => Console.WriteLine("Dog barks");
  public new void Eat() => Console.WriteLine("Dog eats");
}
