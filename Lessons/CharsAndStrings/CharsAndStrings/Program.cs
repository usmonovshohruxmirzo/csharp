using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

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


            // Immutability of strings
            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new
            // string object and stores it in s1, releasing the
            // reference to the original object.
            s1 += s2;

            Console.WriteLine(s1);

            string str1 = "Hello ";
            string str2 = str1;
            str1 += "World";
            Console.WriteLine(str2);

            // Quoted string literals
            string columns = "Column1\tColumn2\tColumn3";
            Console.WriteLine(columns);

            string rows = "Row 1\r\nRow 2\r\nRow 3";
            Console.WriteLine(rows);

            string title = "\"The \u00C6olean Harp\", by Samuel Taylor Coleridge";
            Console.WriteLine(title);

            // Verbatim string literals - Verbatim string literals are more convenient for multi-line strings
            string text = @"My pensive SARA ! thy soft cheek reclined
                Thus on mine arm, most soothing sweet it is
                To sit beside our Cot,...";
            Console.WriteLine(text);

            string filePath = @"C:\Users\scoleridge\Documents\";
            Console.WriteLine(filePath);

            string quote = @"Her name was ""Sara."""; // Escaped " in verbatim
            Console.WriteLine(quote);

            // Raw string literals

            string singleLine = """Friends say "hello" as they pass by.""";
            string multiLine = """
                "Hello World!" is typically the first program someone writes.
            """;
            string embeddedXML = """
               <element attr = "content">
                   <body style="normal">
                       Here is the main text
                   </body>
                   <footer>
                       Excerpts from "An amazing story"
                   </footer>
               </element >
            """;
            Console.WriteLine(embeddedXML);

            string jsonString = """
                {
                    "Date": "2019-08-01T00:00:00-07:00",
                    "TemperatureCelsius": 25,
                    "Summary": "Hot",
                    "DatesAvailable": [
                    "2019-08-01T00:00:00-07:00",
                    "2019-08-02T00:00:00-07:00"
                    ],
                    "TemperatureRanges": {
                    "Cold": {
                        "High": 20,
                        "Low": -10
                    },
                    "Hot": {
                        "High": 60,
                        "Low": 20
                    }
                            },
                    "SummaryWords": [
                    "Cool",
                    "Windy",
                    "Humid"
                    ]
                }
             """;
            Console.WriteLine(jsonString);

            // Format strings
            var jh = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
            Console.WriteLine($"{jh.firstName} {jh.lastName} was an African American poet born in {jh.born}.");
            Console.WriteLine($"He was first published in {jh.published} at the age of {jh.published - jh.born}.");
            Console.WriteLine($"He'd be over {Math.Round((2018d - jh.born) / 100d) * 100d} years old today.");

            int X = 2;
            int Y = 3;

            var pointMessage = $$"""The point {{{X}}, {{Y}}} is {{Math.Sqrt(X * X + Y * Y)}} from the origin.""";

            Console.WriteLine(pointMessage);

            // Verbatim string interpolation
            var jh2 = (firstName: "Jupiter", lastName: "Hammon", born: 1711, published: 1761);
            Console.WriteLine($@"{jh2.firstName} {jh2.lastName}
                                was an African American poet born in {jh2.born}.");
            Console.WriteLine(@$"He was first published in {jh2.published}
                                at the age of {jh2.published - jh2.born}.");

            // Composite formatting
            var pw = (firstName: "Phillis", lastName: "Wheatley", born: 1753, published: 1773);
            Console.WriteLine("{0} {1} was an African American poet born in {2}.", pw.firstName, pw.lastName, pw.born);
            Console.WriteLine("She was first published in {0} at the age of {1}.", pw.published, pw.published - pw.born);
            Console.WriteLine("She'd be over {0} years old today.", Math.Round((2018d - pw.born) / 100d) * 100d);

            // Substrings
            string s3 = "Visual C# Express";
            Console.WriteLine(s3.Substring(7, 2));

            Console.WriteLine(s3.Replace("C#", "Basic"));

            int index = s3.IndexOf("C");
            Console.WriteLine(index);

            // Accessing individual characters
            string s5 = "Printing backwards";

            for (int i = 0; i < s5.Length; i++)
            {
                Console.Write(s5[s5.Length - i - 1]);
            }

            Console.WriteLine();

            string question = "hOW DOES mICROSOFT wORD DEAL WITH THE cAPS lOCK KEY?";
            System.Text.StringBuilder sb = new System.Text.StringBuilder(question);

            for (int j = 0; j < sb.Length; j++)
            {
                if (System.Char.IsLower(sb[j]))
                {
                    sb[j] = System.Char.ToUpper(sb[j]);
                }
                else if (System.Char.IsUpper(sb[j]))
                {
                    sb[j] = System.Char.ToLower(sb[j]);
                }
            }

            string corrected = sb.ToString();
            System.Console.WriteLine(corrected);

            // Null strings and empty strings

            string str3 = "hello";
            string? nullStr = null;
            string emptyStr = String.Empty;

            string tempStr = str3 + nullStr;
            Console.WriteLine(tempStr);

            bool b3 = (emptyStr == nullStr);
            Console.WriteLine(b3);

            string newStr = emptyStr + nullStr;
            Console.WriteLine(emptyStr.Length);
            Console.WriteLine(newStr.Length);

            string s7 = "\x0" + "abc";
            string s8 = "abc" + "\x0";
            Console.WriteLine("*" + s7 + "*");
            Console.WriteLine("*" + s8 + "*");
            Console.WriteLine(s8.Length);


            // Using StringBuilder for fast string creation
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder("Rat: the ideal pet");
            sb2[0] = 'C';
            Console.WriteLine(sb2.ToString());

            var sb3 = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                sb3.Append(i.ToString());
            }
            Console.WriteLine(sb3);

            sb3[0] = sb3[9];

            Console.WriteLine(sb3);

            // How to determine whether a string represents a numeric value
            /*
             TryParse in C# is a method used to safely convert a string to a value type (like int, long, byte, decimal, etc.) without throwing an exception if the conversion fails.
             Instead, it returns a boolean indicating success or failure, and outputs the converted value via an out parameter.
             */

            int numberr;
            bool resultt = int.TryParse("123", out numberr);
            Console.WriteLine(resultt);

            resultt = int.TryParse("abc", out numberr);
            Console.WriteLine(resultt);

            int i3 = 0;
            string s4 = "108";
            bool result = int.TryParse(s4, out i3);
            Console.WriteLine(result);

            string numString = "1287543"; //"1287543.0" will return false for a long
            long number1 = 0;
            bool canConvert = long.TryParse(numString, out number1);
            if (canConvert) Console.WriteLine($"number1 now = {number1}");
            else Console.WriteLine("numString is not a valid long");

            byte number2 = 0;
            numString = "255"; // A value of 256 will return false
            canConvert = byte.TryParse(numString, out number2);
            if (canConvert) Console.WriteLine($"number2 now = {number2}");
            else Console.WriteLine("numString is not a valid byte");

            decimal number3 = 0;
            numString = "27.3"; //"27" is also a valid decimal
            canConvert = decimal.TryParse(numString, out number3);
            if (canConvert) Console.WriteLine($"number3 now = {number3}");
            else Console.WriteLine("number3 is not a valid decimal");


            // String interpolation using $
            var namee = "Alex";
            var date = DateTime.Now;
            // Composite formatting:
            Console.WriteLine("Hello, {0}! Today is {1}, it's {2:HH:mm} now.", namee, date.DayOfWeek, date);
            // String interpolation:
            Console.WriteLine($"Hello, {namee}! Today is {date.DayOfWeek}, it's {date:HH:mm:ss} now.");

            // Structure of an interpolated string
            //{< interpolationExpression > [,< width >][:< formatString >]} 
            Console.WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 40;
            Console.WriteLine($"{Math.PI, FieldWidthRightAligned} - default formatting of the pi number");
            Console.WriteLine($"{Math.PI, FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");

            //Console.Write("Enter num: ");
            //int safetyScore;
            //if (int.TryParse(Console.ReadLine(), out safetyScore))
            //{
            //    string message = $"The usage policy for {safetyScore} is {safetyScore switch
            //    {
            //        > 90 => "Unlimited usage",
            //        > 80 => "General usage, with daily safety check",
            //        > 70 => "Issues must be addressed within 1 week",
            //        > 50 => "Issues must be addressed within 1 day",
            //        _ => "Issues must be addressed before continued use",
            //    }}";
            //    Console.WriteLine(message);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid input. Please enter a valid number.");
            //}

            // Interpolated raw string literals

            int X2 = 2;
            int Y2 = 3;

            var pointMessage2 = $"""The point "{X2}, {Y2}" is {Math.Sqrt(X2 * X2 + Y2 * Y2):F3} from the origin""";
            var pointMessage3 = $$"""{The point {{{X2}}, {{Y2}}} is {{Math.Sqrt(X2 * X2 + Y2 * Y2):F3}} from the origin}""";
            var pointMessage4 = $$$""""{{The point {{{X2}}}, {{{Y2}}}} is {{{Math.Sqrt(X2 * X2 + Y2 * Y2):F3}}} from the origin}"""";
            var pointMessage5 = $$$$"""""{{The point {{{{X2}}}}, {{{{Y2}}}}} is {{{{Math.Sqrt(X2 * X2 + Y2 * Y2):F3}}}} from the origin}""""";
            Console.WriteLine(pointMessage2);
            Console.WriteLine(pointMessage3);
            Console.WriteLine(pointMessage4);
            Console.WriteLine(pointMessage5);

            // Special characters
            string name2 = "Horace";
            int age2 = 34;
            Console.WriteLine($"He asked, \"Is your name {name}?\", but didn't wait for a reply :-{{");
            Console.WriteLine($"{name2} is {age2} year{(age2 == 1 ? "" : "s")} old.");

            //Culture - specific formatting
            double speedOfLight = 299792.458;

            System.Globalization.CultureInfo.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("nl-NL");
            string messageInCurrentCulture = $"The speed of light is {speedOfLight:N3} km/s.";

            var specificCulture = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            string messageInSpecificCulture = string.Create(
                specificCulture, $"The speed of light is {speedOfLight:N3} km/s.");

            string messageInInvariantCulture = string.Create(
                System.Globalization.CultureInfo.InvariantCulture, $"The speed of light is {speedOfLight:N3} km/s.");

            Console.WriteLine($"{System.Globalization.CultureInfo.CurrentCulture,-10} {messageInCurrentCulture}");
            Console.WriteLine($"{specificCulture,-10} {messageInSpecificCulture}");
            Console.WriteLine($"{"Invariant",-10} {messageInInvariantCulture}");
        }
    }
}