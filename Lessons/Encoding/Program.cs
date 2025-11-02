using System;
using System.Text;

namespace Program
{
    class Program
    {
        // INFO: Unicode Transformation Format (UTF) = a method of representing Unicode characters as bytes.
        static void Main(string[] args)
        {
            string text = "Hello";

            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine("UTF-8 Bytes: " + BitConverter.ToString(utf8Bytes));
        }
    }
}
