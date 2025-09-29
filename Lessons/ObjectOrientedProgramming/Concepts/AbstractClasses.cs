namespace ObjectOrientedProgramming.Concepts
{
    public class AbstractClasses
    {
        public static void RunAbstractClasses()
        {
            Car c = new Car() { Make = "Ford", Model = "Escort" };
            Motorcycle m = new Motorcycle() { Make = "Triumph", Model = "Thunderbird" };

            Console.WriteLine(c);
            c.SoundHorn();
            Console.WriteLine(m);
            m.SoundHorn();
        }
    }
}

public abstract class Vehicle
{
    public Vehicle() { }

    public required string Model
    {
        get;
        init;
    }

    public required string Make
    {
        get;
        init;
    }

    public virtual void SoundHorn()
    {
        Console.WriteLine("Add horn sound here");
    }

    public override string ToString()
    {
        return $"{GetType()}: {Make} {Model}";
    }
}

public class Car : Vehicle
{
    public Car()
    {
    }
    public override void SoundHorn()
    {
        Console.WriteLine("Beep Beep");
    }
}

public class Motorcycle : Vehicle
{
    public Motorcycle()
    {
    }

    public override void SoundHorn()
    {
        Console.WriteLine("Honk Honk");
    }
}
