using System.Text;
using StringExtensions;
using ReferenceParamsDemoApp;

namespace MethodsAdvancedFeatures
{
    public static class Program
    {
        public static void Main()
        {
            double ItemPrice = 100;
            AddTax(ref ItemPrice);
            Console.WriteLine(ItemPrice);

            GetCoordinates(out int a, out int b);
            Console.WriteLine($"x: {a}, y: {b}");

            Point point = new Point { X = 3, Y = 4 };
            PrintPoint(in point);

            int[] data = new int[] { 100, 200, 300 };
            ref readonly int first = ref GetFirst(in data);
            Console.WriteLine(first);

            PrintNames("Alice", "Bob", "Charlie");
            Console.WriteLine();

            var person = GetPerson();
            var (name, age) = GetPerson(); // destructuring
            Console.WriteLine($"Name: {name}, Age: {age}");
            Console.WriteLine($"Name: {person.name}, Age: {person.age * 2}");

            string user = "shoxruxmirzo";
            Console.WriteLine(user.ToTitleCase());

            string user2 = "html css js ts py";
            Console.WriteLine(user2.ToKebabCase());
            Console.WriteLine(user2.ToSnakeCase());
            Console.WriteLine(user.ToSpongeCase());


            // App demo
            Console.WriteLine("\nAPP DEMO =========================================\n");
            App.CreateProduct(out Product newProduct, 10, "Tablet", 400);

            App.ApplyTax(ref newProduct, 18);

            App.PrintProduct(in newProduct);

            ref readonly var selectedProduct = ref App.GetProductById(2);
            Console.WriteLine($"Readonly Product: {selectedProduct.Name}, ${selectedProduct.Price}");

            App.GreetCustomers("Ali", "Bobur", "Zarina");

            double discountedPrice = newProduct.Price.ApplyDiscount(10);
            Console.WriteLine($"Discounted Price: ${discountedPrice:F2}");

            var productList = new List<Product> { newProduct, selectedProduct };
            var (count, total) = App.GetSummary(productList);
            Console.WriteLine($"Product Count: {count}, Total: ${total:F2}");
        }
        //  1. ref, out, in, readonly ref – Pass by Reference
        // Used to pass a variable by reference to a method so that the method can access or modify the original data.

        // ref - Read and Write Access
        /*
         * Requires the variable to be initialized before passing.
         * Method can read and change the value.
         */
        public static void AddTax(ref double price)
        {
            price += price * 0.2;
        }

        // out - Output only
        public static void GetCoordinates(out int x, out int y)
        {
            x = 20;
            y = 20;
        }

        // in - Read-Only Reference
        public struct Point
        {
            public int X;
            public int Y;
        }

        public static void PrintPoint(in Point p)
        {
            Console.WriteLine($"X: {p.X}, Y: {p.Y}");
        }

        //  readonly ref
        public static ref readonly int GetFirst(in int[] arr)
        {
            return ref arr[0]; // Read-only reference
        }


        // params – Variable Number of Arguments
        public static void PrintNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }
        }

        // Tuples – Return Multiple Values from a Method
        public static (string name, int age) GetPerson()
        {
            return ("Alex", 45);
        }

    }
}

// Extension Methods – Add Methods to Existing Types
namespace StringExtensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            return char.ToUpper(input[0]) + input.Substring(1).ToLower();
        }

        public static string ToKebabCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            return string.Join("-", input.Split(" "));
        }

        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            return string.Join("_", input.Split(" "));
        }

        public static string ToSpongeCase(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input;

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if ((i & 1) == 0) sb.Append(char.ToUpper(input[i]));
                else sb.Append(char.ToLower(input[i]));
            }
            return sb.ToString().Trim();
        }
    }

}

namespace ReferenceParamsDemoApp
{
    public struct Product
    {
        public int Id;
        public string Name;
        public double Price;
    }

    public static class Extensions
    {
        public static double ApplyDiscount(this double price, double percent)
        {
            return price - (price * percent / 100);
        }
    }

    public static class App
    {
        public static void ApplyTax(ref Product product, double taxPercent)
        {
            product.Price += product.Price * taxPercent / 100;
        }

        public static void CreateProduct(out Product product, int id, string name, double price)
        {
            product = new Product { Id = id, Name = name, Price = price };
        }

        public static void PrintProduct(in Product product)
        {
            Console.WriteLine($"Product: {product.Id}, {product.Name}, ${product.Price:F2}");
        }

        public static readonly Product[] Products = new Product[]
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500 },
            new Product { Id = 2, Name = "Mouse", Price = 25 },
            new Product { Id = 3, Name = "Keyboard", Price = 75 }
        };

        public static ref readonly Product GetProductById(int id)
        {
            for (int i = 0; i < Products.Length; i++)
            {
                if (Products[i].Id == id)
                {
                    return ref Products[i];
                }
            }
            throw new ArgumentException("Product not found");
        }

        public static void GreetCustomers(params string[] names)
        {
            foreach(var name in names)
            {
                Console.WriteLine($"Hello, {name}!");
            }
        }

        public static (int count, double price) GetSummary(List<Product> products)
        {
            int count = products.Count;
            double total = 0;
            foreach(var product in products)
            {
                total += product.Price;
            }
            return (count, total);
        }

    }
}
