namespace Strings
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


            //  INFO: String Formatting =================================================
            int[] quaters = { 1, 2, 3, 4 };
            int[] sales = { 10000, 20000, 3000, 4000 };
            double[] intlMixPct = { .385, .413, .422, .455 };
            int val1 = 1234;
            decimal val2 = 1234.5768m;

            Console.WriteLine("val1 {0}", val1);
            Console.WriteLine("{0:D}, {0:N}, {0:F}, {0:G}, {0:X}", val1);

            Console.WriteLine("{0,12} {1,12} {2,12} {3,12}", quaters[0], quaters[1], quaters[2], quaters[3]);
            Console.WriteLine("{0,12:C2} {1,12:C0} {2,12:C0} {3,12:C0}", sales[0], sales[1], sales[2], sales[3]);
            Console.WriteLine("{0,12:P0} {1,12:P0} {2,12:P1} {3,12:P2}", intlMixPct[0], intlMixPct[1], intlMixPct[2], intlMixPct[3]);
        }
    }
}
