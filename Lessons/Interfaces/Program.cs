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

            IRandomizable randomizer = new Randomizer();
            string str;
            do
            {
                Console.WriteLine("Enter a number for the upper bound: ");
                str = Console.ReadLine()!;

                try
                {
                    double upperBound = Double.Parse(str);
                    Console.WriteLine("Random number between 0 and {1}: {0}", randomizer.GetRandomNumber(upperBound), upperBound);
                }
                catch (Exception) { }

            } while (str != "exit");
            Console.WriteLine("\nHit Enter key to continue...");
            Console.ReadKey();
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

class Randomizer : IRandomizable
{

    public double GetRandomNumber(double dUpperBound)
    {
        Random random = new Random();
        double seed = random.NextDouble();
        return seed * dUpperBound;
    }
}
