public interface IPrototype<T>
{
    T Clone();
}

public class Character : IPrototype<Character>
{
    public string? Name { get; set; }
    public int Level { get; set; }
    public string? Weapon { get; set; }

    public Character Clone()
    {
        return (Character)this.MemberwiseClone();
    }

    public void ShowCharacter()
    {
        Console.WriteLine($"Name: {Name}, Level: {Level}, Weapon: {Weapon}");
    }
}
