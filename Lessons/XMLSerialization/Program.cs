using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;

[XmlRoot("bookstore")]
public class Bookstore
{
  [XmlElement("book")]
  public List<Book>? Books { get; set; }
}

public class Book
{
  [XmlAttribute("category")]
  public string? Category { get; set; }

  [XmlAttribute("cover")]
  public string? Cover { get; set; }

  [XmlElement("title")]
  public Title? Title { get; set; }

  [XmlElement("author")]
  public List<string>? Authors { get; set; }

  [XmlElement("year")]
  public int Year { get; set; }

  [XmlElement("price")]
  public decimal Price { get; set; }
}

public class Title
{
  [XmlAttribute("lang")]
  public string? Lang { get; set; }

  [XmlText]
  public string? Text { get; set; }
}

class Program
{
  static void Main()
  {
    XmlSerializer serializer = new(typeof(Bookstore));
    using (FileStream fs = new("books.xml", FileMode.Open))
    {
      Bookstore store = (Bookstore)serializer.Deserialize(fs)!;

      foreach (var book in store.Books!)
      {
        Console.WriteLine($"Category: {book.Category}, Cover: {book.Cover ?? "N/A"}");
        Console.WriteLine($"Title: {book?.Title?.Text} ({book?.Title?.Lang})");
        Console.WriteLine($"Year: {book?.Year}, Price: {book?.Price}");
        
        foreach (var author in book?.Authors!)
        {
          Console.WriteLine($"Author: {author}");
        }
        Console.WriteLine(new string('-', 30));
      }
    }

    var newStore = new Bookstore
    {
      Books = new List<Book>
            {
                new Book
                {
                    Category = "cooking",
                    Title = new Title { Lang = "en", Text = "Everyday Italian" },
                    Authors = new List<string> { "Giada De Laurentiis" },
                    Year = 2005,
                    Price = 30.00m
                },
                new Book
                {
                    Category = "web",
                    Cover = "paperback",
                    Title = new Title { Lang = "en", Text = "Learning XML" },
                    Authors = new List<string> { "Erik T. Ray" },
                    Year = 2003,
                    Price = 39.95m
                }
            }
    };
    XmlSerializer serializer1 = new(typeof(Bookstore));
    using (FileStream fs = new("new_books.xml", FileMode.Create))
    {
      serializer1.Serialize(fs, newStore);
    }

    // XmlDocument doc = new();
    // doc.Load("books.xml");
    // XmlNodeList books = doc.SelectNodes("/bookstore/book");
    // foreach (XmlNode book in books)
    // {
    //   string category = book.Attributes["category"].Value;
    //   string title = book["title"].InnerText;
    //
    //   Console.WriteLine($"Category: {category}, Title: {title}");
    //
    //   XmlNodeList authors = book.SelectNodes("author");
    //   foreach (XmlNode author in authors)
    //   {
    //     Console.WriteLine($"Author: {author.InnerText}");
    //   }
    //
    //   Console.WriteLine(new string('-', 20));
    // }

    XDocument doc = XDocument.Load("books.xml");
    var books = doc.Descendants("book");
    foreach (var book in books)
    {
      string category = (string)book.Attribute("category")!;
      string title = (string)book.Attribute("title")!;
      Console.WriteLine($"Category: {category}, Title: {title}");

      var authors = book.Elements("author").Select(a => a.Value);
      foreach (var author in authors)
      {
        Console.WriteLine($"Author: {author}");
      }

      Console.WriteLine(new string('-', 20));
    }
  }
}
