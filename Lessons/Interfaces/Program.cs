using Interfaces.Models;

namespace Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Document d = new Document("Test Document");
            // d.Save();
            // d.Load();

            if (d is IStoreable)
            {
                d.Save();
                d.Decrypt();
            }

            IStoreable istor = d as IStoreable;
            if (istor != null)
            {
                istor.Load();
                d.Encrypt();
            }
        }
    }
}




class Document : IStoreable, IEncryptable
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

    public void Encrypt()
    {
        Console.WriteLine("Encrypting the document");
    }

    public void Decrypt()
    {
        Console.WriteLine("Decrypting the document");
    }

}
