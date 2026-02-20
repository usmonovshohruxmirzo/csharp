// using System.Text.Json;
// using System.Xml.Serialization;
//
// namespace JSONSerialization
// {
//   class Program
//   {
//     static void Main(string[] args)
//     {
//       var person = PersonFactory.Person();
//       var options = new JsonSerializerOptions() { WriteIndented = true };
//       string json = JsonSerializer.Serialize(person, options);
//       Console.WriteLine(json);
//
//       var p2 = JsonSerializer.Deserialize<Person>(json);
//       Console.WriteLine(p2?.FirstName);
//
//       // XML
//       var serializer = new XmlSerializer(typeof(Person));
//       using (var writer = new StreamWriter("person.xml"))
//       {
//         serializer.Serialize(writer, person);
//       }
//
//       using (var reader = new StreamReader("person.xml"))
//       {
//         Person p3 = (Person)serializer.Deserialize(reader)!;
//         Console.WriteLine(p3);
//       }
//     }
//   }
// }

using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Text.Json.Serialization.Metadata;
using System.IO;
using System.Threading.Tasks;

#region Models

public enum CompanyType
{
  Startup,
  Enterprise,
  Government
}

public record Address(string City, string Country);

public abstract class Employee
{
  public required string Name { get; set; }
}

public class Developer : Employee
{
  public string PrimaryLanguage { get; set; } = string.Empty;
}

public class Manager : Employee
{
  public int TeamSize { get; set; }
}

public class Company
{
  [JsonPropertyName("company_name")]
  public string Name { get; set; } = string.Empty;

  [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
  public string? InternalCode { get; set; }

  [JsonInclude]
  public DateTime Founded { get; private set; }

  public CompanyType Type { get; set; }

  public Address Address { get; set; } = new("", "");

  public List<Employee> Employees { get; set; } = new();

  public Dictionary<string, string> Metadata { get; set; } = new();

  public Company? PartnerCompany { get; set; }

  public Company(DateTime founded)
  {
    Founded = founded;
  }
}

#endregion

#region Custom Converter

public class CustomDateConverter : JsonConverter<DateTime>
{
  public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
      => DateTime.Parse(reader.GetString()!);

  public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
      => writer.WriteStringValue(value.ToString("yyyy-MM-dd"));
}

#endregion

#region JsonSerializationService

public static class JsonSerializationService
{
  public static JsonSerializerOptions GetOptions()
  {
    var options = new JsonSerializerOptions
    {
      WriteIndented = true,
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
      ReferenceHandler = ReferenceHandler.IgnoreCycles,
      Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
      PropertyNameCaseInsensitive = true
    };

    options.Converters.Add(new JsonStringEnumConverter());
    options.Converters.Add(new CustomDateConverter());

    // Polymorphism (.NET 7+)
    options.TypeInfoResolver = new DefaultJsonTypeInfoResolver
    {
      Modifiers =
            {
                ti =>
                {
                    if (ti.Type == typeof(Employee))
                    {
                        ti.PolymorphismOptions = new JsonPolymorphismOptions
                        {
                            TypeDiscriminatorPropertyName = "$type",
                            DerivedTypes =
                            {
                                new JsonDerivedType(typeof(Developer), "developer"),
                                new JsonDerivedType(typeof(Manager), "manager")
                            }
                        };
                    }
                }
            }
    };

    return options;
  }

  public static string Serialize<T>(T obj)
      => JsonSerializer.Serialize(obj, GetOptions());

  public static T? Deserialize<T>(string json)
      => JsonSerializer.Deserialize<T>(json, GetOptions());

  public static async Task SerializeToFileAsync<T>(string filePath, T obj)
  {
    await using var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
    await JsonSerializer.SerializeAsync(fs, obj, GetOptions());
  }

  public static async Task<T?> DeserializeFromFileAsync<T>(string filePath)
  {
    await using var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
    return await JsonSerializer.DeserializeAsync<T>(fs, GetOptions());
  }
}

#endregion

#region Program

class Program
{
  static async Task Main()
  {
    var company = new Company(DateTime.Now)
    {
      Name = "WebBro Software",
      Type = CompanyType.Startup,
      Address = new Address("Tashkent", "Uzbekistan"),
      Metadata = new Dictionary<string, string>
            {
                { "FoundedBy", "Shohrux" },
                { "Vision", "Global Tech" }
            },
      Employees = new List<Employee>
            {
                new Developer { Name = "Ali", PrimaryLanguage = "C#" },
                new Manager { Name = "Vali", TeamSize = 5 }
            }
    };

    // Circular reference test
    company.PartnerCompany = company;

    // Serialize to string
    string json = JsonSerializationService.Serialize(company);
    Console.WriteLine("Serialized JSON:\n");
    Console.WriteLine(json);

    // Deserialize from string
    var deserialized = JsonSerializationService.Deserialize<Company>(json);
    Console.WriteLine("\nDeserialized Company Name: " + deserialized?.Name);

    // Serialize to file
    string filePath = "company.json";
    await JsonSerializationService.SerializeToFileAsync(filePath, company);

    // Deserialize from file
    var fromFile = await JsonSerializationService.DeserializeFromFileAsync<Company>(filePath);
    Console.WriteLine("\nLoaded From File: " + fromFile?.Name);
  }
}

#endregion
