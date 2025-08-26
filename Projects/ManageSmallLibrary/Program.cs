using System.Linq;

namespace ManageSmallLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = Data.Books;
            var authors = Data.Authors;
            var members = Data.Members;

            foreach (var book in books)
            {
              Console.WriteLine(book.GetType().GetProperty("Title").GetValue(book));
            }
        }
    }
}
