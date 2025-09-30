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

            var collection = new StringCollection();

            collection[0] = "   Apple   ";
            collection[1] = "Banana";
            collection[2] = "Cherry";

            Console.WriteLine(collection[0]); // Apple (trimmed)
            Console.WriteLine(collection[1]); // Banana
            Console.WriteLine(collection[2]); // Cherry
            Console.WriteLine("Length: " + collection.Length); // 3

            // Reverse lookup by string
            Console.WriteLine("Index of 'Banana': " + collection["Banana"]); // 1
            Console.WriteLine("Index of 'Mango': " + collection["Mango"]);   // -1

            // Auto resize works
            collection[20] = "Orange";
            Console.WriteLine(collection[20]); // Orange
            Console.WriteLine("Length: " + collection.Length); // 21

            // Out of range safe read
            Console.WriteLine(collection[100]); // [Index out of range]
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

// INFO: Abstract Indexers
//
public abstract class CollectionBase
{
    public abstract string this[int index] { get; set; }
}

public class StringCollection : CollectionBase
{
    private string[] items;

    public int Length { get; private set; } = 0;

    public StringCollection(int capacity = 5)
    {
        items = new string[capacity];
    }

    // Indexer: access by int
    public override string this[int index]
    {
        get
        {
            if (index < 0 || index >= Length)
            {
                return "[Index out of range]";
            }

            return items[index] ?? "[null]";
        }
        set
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            // Auto expand if needed
            if (index >= items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[index] = (value ?? "").Trim();
            if (index >= Length) Length = index + 1;
        }
    }

    // Extra indexer: access by string (reverse lookup)
    public int this[string value]
    {
        get
        {
            value = value?.Trim() ?? "";
            for (int i = 0; i < Length; i++)
            {
                if (items[i] == value) return i;
            }
            return -1; // not found
        }
    }
}

// INFO: Abstract Events
// 
public abstract class ButtonBase
{
  public abstract event EventHandler Click;
}

public class Button : ButtonBase
{
  public override event EventHandler Click;

  public void SimulateClick()
  {
    Click?.Invoke(this, EventArgs.Empty);
  }
}
