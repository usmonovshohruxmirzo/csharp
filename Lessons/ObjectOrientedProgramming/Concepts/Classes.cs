using System.Diagnostics.CodeAnalysis;

namespace ObjectOrientedProgramming.Concepts
{
    public class Classes
    {
        public static void RunClasses()
        {
            Book b1 = new Book("Hello", "World", 800);
            Console.WriteLine(b1.GetDescription());
            b1.SetName("JS");
            Console.WriteLine(b1.GetDescription());

            Console.WriteLine(b1.Name);
            Console.WriteLine(b1.Author);

            b1.ISBN = "1234654894312";
            b1.Price = 24.58m;
            Console.WriteLine(b1.ISBN);
            Console.WriteLine(b1.Price);

            b1.Name = "Crime and Punishment";
            b1.PageCount = 454;
            Console.WriteLine(b1.Description);
            Console.WriteLine(b1.Name);
            Console.WriteLine(b1.PageCount);
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

    // INFO: Backing Field
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

    // INFO: expression-bodied properties
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

    // INFO: Computed property
    public string Description
    {
        get => $"{Name} by {Author}, {PageCount} pages";
    }

    // INFO: Auto-generated properties
    public string ISBN
    {
        get; set;
    }

    public decimal Price
    {
        get; set;
    }


    public string GetDescription()
    {
        return $"{_name} by {_author}, {_pageCount} pages";
    }

    public string GetName()
    {
        return _name;
    }

    public void SetName(string s)
    {
        _name = s;
    }
}

class Person
{
    public required string Name { get; set; }
    public string Job { get; private set; }

    [SetsRequiredMembers]
    public Person(string name, string job)
    {
        Name = name;
        Job = job;
    }
}
