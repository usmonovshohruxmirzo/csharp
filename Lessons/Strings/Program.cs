using System.Globalization;
using System.Text;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            //  INFO: Strings =================================================
            string outStr;
            string str1 = "The quick brown fox jumps over the lazy dog";
            string str2 = "This is a string";
            string str3 = "THIS is a STRING";
            string[] strs = { "one", "two", "three", "four" };

            Console.WriteLine(str1.Length);

            Console.WriteLine(str1[0]);

            foreach (var ch in str1)
            {
                Console.Write(ch);
                if (ch == 'b')
                {
                    Console.WriteLine();
                    break;
                }
            }

            outStr = String.Concat(strs);
            Console.WriteLine(outStr);

            outStr = String.Join("---", strs);
            Console.WriteLine(outStr);

            int result = String.Compare(str2, "This is a string");
            Console.WriteLine(result);

            bool isEqual = str2.Equals(str3);
            Console.WriteLine(isEqual);


            Console.WriteLine(str1.IndexOf('e'));
            Console.WriteLine(str1.LastIndexOf("the"));

            outStr = str1.Replace("fox", "cat");
            Console.WriteLine(outStr);
            Console.WriteLine(outStr.IndexOf("fox"));


            // INFO: String Formatting =================================================
            // General Format is {index[,alignment]:[format]}
            // Common Types are N (Number), G (General), F (Fixed-point)
            // E (Exponential), D (Decimal), G (General), X (Xexadecimal), C (Currency in local format)

            int[] quaters = { 1, 2, 3, 4 };
            int[] sales = { 10000, 20000, 3000, 4000 };
            double[] intlMixPct = { .385, .413, .422, .455 };
            int val1 = 1234;
            decimal val2 = 1234.5768m;

            Console.WriteLine("val1 {0}", val1);
            Console.WriteLine("{0:D}, {0:N}, {0:F}, {0:G}, {0:X}", val1);

            Console.WriteLine("{0,12} {1,12} {2,12} {3,12}", quaters[0], quaters[1], quaters[2], quaters[3]);
            Console.WriteLine("{0,12:C2} {1,12:C0} {2,12:C0} {3,12:C0}", sales[0], sales[1], sales[2], sales[3]);

            CultureInfo euroCulture = new CultureInfo("de-DE");

            Console.WriteLine("{0,12:C2} {1,12:C0} {2,12:C0} {3,12:C0}",
                sales[0].ToString("C2", euroCulture),
                sales[1].ToString("C0", euroCulture),
                sales[2].ToString("C0", euroCulture),
                sales[3].ToString("C0", euroCulture));

            Console.WriteLine("{0,12:P0} {1,12:P0} {2,12:P1} {3,12:P2}", intlMixPct[0], intlMixPct[1], intlMixPct[2], intlMixPct[3]);

            // INFO: String Interpolation

            string make = "Mercedes-Benz";
            string model = "G Class";
            int year = 2020;
            float miles = 8_450.27f;
            decimal price = 60_275.0m;
            Console.WriteLine("This car is a {0} {1} {2}, with {3} miles and costs {4:C2}", year, make, model, miles, price);

            Console.WriteLine($"This car is a {year} {make} {model}, with {miles} miles and costs {price:C2}");

            Console.WriteLine($"This car is a {year} {make} {model}, with {{{miles * 1.6:F2}}} miles and costs {price:C2}");

            // INFO: StringBuilder

            StringBuilder sb = new StringBuilder("Initial String. ", 200);
            int jumpCount = 10;
            string[] animals = { "goats", "cats", "pigs" };

            // print some basic stats about the StringBuilder
            Console.WriteLine($"Capacity: {sb.Capacity}; Length: {sb.Length}");

            // Add some strings to the builder using Append
            sb.Append("The quick brown fox ");
            sb.Append("jumps over the lazy dog.");

            // AppendLine can append a line ending
            sb.AppendLine();

            // AppendFormat can be used to append formatted strings
            sb.AppendFormat("He did this {0} times.", jumpCount);
            sb.AppendLine();

            // AppendJoin can iterate over a set of values
            sb.Append("He also jumped over ");
            sb.AppendJoin(",", animals);

            // Modify the content using Replace
            sb.Replace("fox", "cat");

            // Insert content at any index
            sb.Insert(0, "This is the ");

            Console.WriteLine($"Capacity: {sb.Capacity}; Length: {sb.Length}");

            // Convert to a single string
            Console.WriteLine(sb.ToString());

            // INFO: String Parsing
        }
    }
}
