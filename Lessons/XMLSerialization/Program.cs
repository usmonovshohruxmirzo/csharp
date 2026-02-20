using System.Text.Json;
using System.Xml.Serialization;

namespace XMLSerialization
{
  class Program
  {
    static void Main(string[] args)
    {
    }
  }

}

[XmlRoot("bookstrore")]
class Bookstrore
{
  public List<Book>? Books { get; set; }
}

class Book
{
  [XmlAttribute("category")]
  public string Category { get; set; }

  [XmlAttribute("cover")]
  public string Cover { get; set; }

  [XmlElement("title")]
  public Title Title { get; set; }

  [XmlElement("author")]
  public List<string> Authors { get; set; }

  [XmlElement("year")]
  public int Year { get; set; }

  [XmlElement("price")]
  public decimal Price { get; set; }
}

public class Title
{
  [XmlAttribute("lang")]
  public string Lang { get; set; }

  [XmlText]
  public string Text { get; set; }
}
