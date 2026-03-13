using System.Threading.Channels;
using ContosoPizza.Data;
using ContosoPizza.Models;

namespace EFCore
{
  class Program
  {
    static void Main(string[] args)
    {
      using ContosoPizzaContext context = new ContosoPizzaContext();

      var commands = new Dictionary<string, Action>
      {
        ["list"] = () => ListProducts(context),
        ["add"] = () => AddProduct(context),
        ["remove"] = () => RemoveProduct(context)
      };

      bool exit = false;

      while (!exit)
      {
        Console.WriteLine("> Enter option: ");
        string option = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
        if (commands.TryGetValue(option, out var action))
        {
          action();
        }
        else{
          Console.WriteLine("Invalid command");
        }
      }
    }

    static void ListProducts(ContosoPizzaContext context)
    {
      var products = context.Products.OrderBy(p => p.Name).ToList();
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine("\u001b[1m--- Products ---");
      foreach (var p in products)
      {
        Console.WriteLine($"Id:    {p.Id}");
        Console.WriteLine($"Name:  {p.Name}");
        Console.WriteLine($"Price: {p.Price:C}");
        Console.WriteLine(new string('-', 20));
      }
      Console.WriteLine("\u001b[0m");
    }

    static void AddProduct(ContosoPizzaContext context)
    {
      var productName = Helpers.ReadString("Enter product name: ");
      var productPrice = Helpers.ReadInt("Enter product price: ");
      var product = new Product { Name = productName, Price = productPrice };
      context.Products.Add(product);
      context.SaveChanges();
      Console.WriteLine("Product {0} added successfully!", productName);
    }

    static void RemoveProduct(ContosoPizzaContext context)
    {
      var id = Helpers.ReadInt("ID: ");
      var product = context.Products.Find(id);
      if (product == null)
      {
        Console.WriteLine("Product {0} not found", id);
      }
      context.Products.Remove(product!);
      context.SaveChanges();
      Console.WriteLine("Product {0} deleted successfully!", id);
    }

  }
}
