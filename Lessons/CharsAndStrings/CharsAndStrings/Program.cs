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

            // Examples
            char chA = 'A';
            char ch1 = '1';
            string str = "test string";

            Console.WriteLine(chA.CompareTo('B')); // Compares chA with 'B' alphabetically based on their Unicode values.
            Console.WriteLine(chA.Equals('A')); // This method converts the character digit '1' into the numeric double 1.0.
            Console.WriteLine(Char.GetNumericValue(ch1)); // This method converts the character digit '1' into the numeric double 1.0.
            Console.WriteLine(Char.IsControl('\t')); // Checks if a character is a control character (like tab \t, newline \n, etc.). These characters control formatting, not text.
            Console.WriteLine(Char.IsDigit(ch1));  // Checks if the character ch1 is a digit (0–9). '1' is a digit → returns true.
            Console.WriteLine(Char.IsLetter(','));  // Checks if the character is a letter (A–Z, a–z, or letters from other languages). ',' is a punctuation mark → false.
            Console.WriteLine(Char.IsLower('u')); // Returns true if the character is a lowercase letter. 'u' is lowercase → true.
            Console.WriteLine(Char.IsNumber(ch1)); // Checks if a character is a numeric character, which includes more than just digits — for example, fractions like ¼, Roman numerals, etc.
            Console.WriteLine(Char.IsPunctuation('.')); // Checks if the character is a punctuation symbol (like . , ! ? : ; etc.).
            Console.WriteLine(Char.IsSeparator(str, 4)); // Checks if the character at index 4 in the string is a separator, like a space or line separator.
            Console.WriteLine(Char.IsSymbol('+')); // Checks if the character is a symbol used in math or currency, like +, =, ¥, %, etc.
            Console.WriteLine(Char.IsWhiteSpace(str, 4)); // Checks if the character at index 4 is whitespace, like
            Console.WriteLine(Char.Parse("S")); // Converts a string of length 1 into a char. If the string has more than one character, it throws an error.
            Console.WriteLine(Char.ToLower('M')); // Converts a uppercase character to lowercase.
            Console.WriteLine('x'.ToString()); // Converts the character 'x' to a string "x". This is useful when you need to join chars into strings.

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

            string sentence = "123abc!";
            int count = sentence.Count(char.IsDigit);
            Console.WriteLine(count);

            // Strings ============================================================================================================

            // Declare without initializing.
            string message1;

            // Initialize to null.
            string? message2 = null;

            // Initialize as an empty string.
            // Use the Empty constant instead of the literal "".
            string message3 = System.String.Empty;

            // Initialize with a regular string literal.
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // Initialize with a verbatim string literal.
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // Use System.String if you prefer.
            System.String greeting = "Hello World!";

            // In local variables (i.e. within a method body)
            // you can use implicit typing.
            var temp = "I'm still a strongly-typed System.String!";

            // Use a const string to prevent 'message4' from
            // being used to store another string value.
            const string message4 = "You can't get rid of me!";

            // Use the String constructor only when creating
            // a string from a char*, char[], or sbyte*. See
            // System.String documentation for details.
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);
            Console.WriteLine(alphabet);

        }
    }
}