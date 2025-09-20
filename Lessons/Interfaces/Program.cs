namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Document d = new Document("Test Document");
            d.Save();
            d.Load();
        }
    }
}

interface ISortable
{
    void Save();
    void Load();
    bool NeedsSave { get; set; }
}

class Document : ISortable
{
    private string name;
    public bool needsSave;

    public Document(string s)
    {
        name = s;
        Console.WriteLine("Created a document with name '{0}'", s);
    }

    public void Save()
    {
      Console.WriteLine("Saving the document");
    }

    public void Load()
    {
      Console.WriteLine("Loading the document");
    }

    public bool NeedsSave
    {
        get { return needsSave; }
        set { needsSave = value; }
    }
}
