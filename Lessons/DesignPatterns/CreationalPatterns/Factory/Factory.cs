public interface IShape
{
  void Draw();
}

public class Circle : IShape
{
  public void Draw() => Console.WriteLine("Drawing Circle");
}

public class Square : IShape
{
  public void Draw() => Console.WriteLine("Drawing Square");
}

public class ShapeFactory
{
    public IShape? GetShape(string shapeType) => shapeType switch
    {
        "Circle" => new Circle(),
        "Square" => new Square(),
        _ => null
    };
}
