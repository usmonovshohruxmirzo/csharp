using System;
using System.Text;

namespace Program
{
    class Program
    {
        // INFO: Unicode Transformation Format (UTF) = a method of representing Unicode characters as bytes.
        // Encoding.ASCII
        // Encoding.UTF8
        // Encoding.Unicode   // UTF-16
        // Encoding.UTF32
        // Encoding.Default   // system default encoding

        static void Main(string[] args)
        {
            Console.WriteLine("️What is Encoding?");
            Console.WriteLine("Encoding = converting text (characters) to bytes.");
            Console.WriteLine("Decoding = converting bytes back to text.\n");

            Console.WriteLine("===========================");

            // BasicEncodingDecoding();
            // EncodingMismatch();
            // FileEncodingExample();
            ConvertEncodingExample();
        }
        
        static void BasicEncodingDecoding()
        {
            Console.WriteLine("Encoding and Decoding Example (UTF-8)\n");

            string text = "Hello";

            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);
            Console.WriteLine("UTF-8 Bytes: " + BitConverter.ToString(utf8Bytes));

            string decoded = Encoding.UTF8.GetString(utf8Bytes);
            Console.WriteLine("Decoded Text: " + decoded);
        }

        static void EncodingMismatch()
        {
            Console.WriteLine("3️⃣ Encoding Mismatch Example\n");

            string text = "Привет";

            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);

            string wrong = Encoding.ASCII.GetString(utf8Bytes);

            Console.WriteLine("Original (UTF-8): " + text);
            Console.WriteLine("Wrong (ASCII decoded): " + wrong + "\n");
        }

        static void FileEncodingExample()
        {
            Console.WriteLine("Writing and Reading Files with Encoding\n");

            string filePath = "encoding_sample.txt";
            string text = "Hello from WebBro Academy";
            File.WriteAllText(filePath, text, Encoding.UTF8);

            string result = File.ReadAllText(filePath, Encoding.UTF8);

            Console.WriteLine($"Written and Read: {result}");
            Console.WriteLine($"File saved at: {Path.GetFullPath(filePath)}\n");
        }

        static void ConvertEncodingExample()
        {
            Console.WriteLine("Convert Between Encodings\n");

            string text = "こんにちは"; // Japanese

            byte[] utf8Bytes = Encoding.UTF8.GetBytes(text);

            // Convert UTF-8 → Unicode (UTF-16)
            byte[] unicodeBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, utf8Bytes);

            // Decode back
            string converted = Encoding.Unicode.GetString(unicodeBytes);
            Console.WriteLine("Original Text: " + text);
            Console.WriteLine("Converted Text: " + converted + "\n");
        }
    }
}
