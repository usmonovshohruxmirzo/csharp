using System;
using System.Text;

namespace CharsAndStrings
{
    public static class Programm
    {
        public static void Main()
        {
            // char 
            var chars = new[]
            {
                    'j',
                    '\u006A',
                    '\x006A',
                    (char)106,
                };
            Console.WriteLine(string.Join(" ", chars));

            char letter = 'A';
            Console.WriteLine(letter);
            Console.WriteLine((int)letter);

            char c1 = (char)65;
            char c2 = '\u0041';
            Console.WriteLine(c1);
            Console.WriteLine(c2);

            char x = 'A';
            char y = x;
            y = 'B';
            Console.WriteLine(x); // It copies the value, not a reference like string.

            // Character Type Checkers:
            char c = 'a';
            Console.WriteLine(char.IsDigit(c));
            Console.WriteLine(char.IsLetter(c));
            Console.WriteLine(char.IsLetterOrDigit(c));
            Console.WriteLine(char.IsWhiteSpace(' '));
            Console.WriteLine(char.IsPunctuation('.'));

            Console.WriteLine(char.ToUpper(c));
            Console.WriteLine(char.ToLower(c));

            // Escape Characters
            char newline = '\n';
            char tab = '\t';

            // Comparing Chars
            char a = 'A';
            char b = 'B';

            Console.WriteLine(a == b); // false
            Console.WriteLine(a < b); // true (since 65 < 66)
            Console.WriteLine(char.ToLower('a') == char.ToLower('A'));

            // Iterating Through a String Using char
            string word = "Hello World";
            foreach (char ch in word)
            {
                Console.Write(ch + " ");
            }
            Console.WriteLine();

            char s = 'S';
            int code = s;
            Console.WriteLine("char: {0}, code: {1}", s, code);

            int code1 = 66;
            char b1 = 'B';
            Console.WriteLine("code: {0}, char: {1}", code1, b1);

            char z = 'Z';
            string zstr = z.ToString();
            Console.WriteLine($"{zstr} {zstr.GetType().Name}");

            string name = "alex";
            char first = name[0];
            Console.WriteLine($"name: {name}, first letter: {first}");

            // Limitations of char
            string emoji = "🙂";
            Console.WriteLine(emoji.Length);
            foreach (Rune rune in emoji.EnumerateRunes())
            {
                Console.WriteLine($"Character: {rune} | Unicode: U+{rune.Value:X4} | IsLetter: {Rune.IsLetter(rune)}");
            }

            // Real - World Usage Examples
            char c3 = '5';
            if (char.IsDigit(c3))
            {
                Console.WriteLine("It's a digit!");
            }
            else
            {
                Console.WriteLine("It's not a digit");
            }

            // Replace the loop with LINQ to address the diagnostic S3267
            string sentence = "123abc!";
            int count = sentence.Count(char.IsDigit);
            Console.WriteLine(count);
        }
    }
}