namespace Structures
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Display()
        {
            Console.WriteLine($"X: {X}, Y: {Y}");
        }
    }

    readonly struct MyStruct
    {
        // public int Value { get; }
        // public int Value { get; init; }
        public static int Value { get; set; }
        // public int Value { get; set; }
        public MyStruct(int value)
        {
            Value = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point point = new(20, 30);
            point.Display();
        }
    }
}
