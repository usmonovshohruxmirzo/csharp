Circle c1 = new Circle(5);
Circle c2 = new Circle(5);
Circle c3 = null!;
Circle c4 = new Circle(10);
Circle c5 = null!;

// Default equality checking compares references, not values
// Implementing the Equals operator overrides can resolve this
Console.WriteLine($"{c1 == c2}");
Console.WriteLine($"{c3 == c5}");
Console.WriteLine($"{c4 == c2}");
Console.WriteLine($"{c4 != c2}");

// Test using Equals methods
Console.WriteLine($"{object.Equals(c1, c2)}");
Console.WriteLine($"{c1.Equals(c2)}");


// 1. Define a class that implements the IEquatable interface
public class Circle : IEquatable<Circle> {
    public Circle(int radius) {
        Radius = radius;
    }

    public int Radius {
        get; set;
    }

    public float Area {
        get => (float)(Math.PI * (Radius * Radius));
    }

    public override string ToString() => $"Circle Radius:{Radius}, Area:{Area}";

    public void Resize(int Size) {
        Radius += Size;
    }

    // Checking value equality requires overriding Equals and GetHashCode, along with == and !=
    // 2. Override the Equals method on object
    public override bool Equals(object? obj) => this.Equals(obj as Circle);

    // 3. Implement an Equals function for this class
    public bool Equals(Circle? c) {
        // if the object being compared to is null, return false
        if (c is null) { return false; }

        // if the run-time types aren't the same, return false
        if (this.GetType() != c.GetType()) {
            return false;
        }

        return (this.Radius == c.Radius);
    }

    // 4. Override GetHashCode
    public override int GetHashCode() => Radius.GetHashCode();

    // 5. Implement the == operator
    public static bool operator == (Circle lhs, Circle rhs)
    {
        if (lhs is null) {
            if (rhs is null) {
                return true;
            }

            // Only the left side is null.
            return false;
        }
        // The instance Equals handles case of null on right-hand side
        return lhs.Equals(rhs);
    }

    // 6. Implement the != operator
    public static bool operator != (Circle lhs, Circle rhs) => !(lhs == rhs);
}
