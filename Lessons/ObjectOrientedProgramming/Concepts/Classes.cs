namespace ObjectOrientedProgramming.Concepts
{
    public class Classes
    {
        public static void RunClasses()
        {
            Book b1 = new Book("Hello", "World", 800);
            Console.WriteLine(b1.GetDescription());
        }
    }
}

class Book
{
    private string _name;
    private string _author;
    private int _pageCount;

    public Book(string name, string author, int pageCount)
    {
        _name = name;
        _author = author;
        _pageCount = pageCount;
    }

    // Backing Field
    public string Name
    {
        get
        {
            return _name;
        }
        set
        {
            _name = value;
        }
    }

    public string Author
    {
        get => _author;
        set => _author = value;
    }

    public int PageCount
    {
        get => _pageCount;
        set => _pageCount = value;
    }

    public string GetDescription()
    {
        return $"{_name} by {_author}";
    }
}
