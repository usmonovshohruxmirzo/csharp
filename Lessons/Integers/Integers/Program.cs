//int a = 10;
//int b = 20;
//int c = a + b;
//Console.WriteLine(c);

// Integer Types in C#
/*
Type	    Size (bits)	    Signed?	        Range

sbyte       8	            Yes	            -128 to 127
byte	    8	            No	            0 to 255
short	    16	            Yes	            -32,768 to 32,767
ushort	    16	            No	            0 to 65,535
int	        32	            Yes	            -2,147,483,648 to 2,147,483,647
uint	    32	            No	            0 to 4,294,967,295
long	    64	            Yes	            -9,223,372,036,854,775,808 to 9,223,372,036,854,775,807
ulong	    64	            No	            0 to 18,446,744,073,709,551,615
 
*/

sbyte a = -120;
byte b = 120;
short c = 20_000;
ushort d = 65_000;
int e = -123456;
uint f = 123456;
long g = -132465L;
ulong h = 132465L;

Console.WriteLine($"{a}, {a.GetType().Name}");
Console.WriteLine($"{b}, {b.GetType().Name}");
Console.WriteLine($"{c}, {c.GetType().Name}");
Console.WriteLine($"{d}, {d.GetType().Name}");
Console.WriteLine($"{e}, {e.GetType().Name}");
Console.WriteLine($"{f}, {f.GetType().Name}");
Console.WriteLine($"{g}, {g.GetType().Name}");
Console.WriteLine($"{h}, {h.GetType().Name}");

int decimalValue = 42;
Console.WriteLine($"decimalValue: {decimalValue}");

int hexValue = 0x2A;
Console.WriteLine($"hexValue: {hexValue}");

int binaryValue = 0b101010;
Console.WriteLine($"binaryValue: {binaryValue}");

int underscore = 1_000_000;
Console.WriteLine(underscore);

//checked
//{
//    int max = int.MaxValue;
//    int result = max + 1;
//}

//unchecked
//{
//    int max = int.MaxValue;
//    int result = max + 1;
//}

/*
 * checked → Stops on overflow (error).
 * unchecked → Ignores overflow (wraps around).
 * 
 * Use `checked` when you need safe calculations.
 * Use `unchecked` when you want performance and don't care about overflow. 
*/


// Bitwise Operations
int a2 = 5; // 0101
int b2 = 3; // 0011

Console.WriteLine(a2 & b2); // Bitwise AND
/*
 * 0 & 0 = 0
 * 1 & 0 = 0
 * 0 & 1 = 0
 * 1 & 1 = 1
 * 0001 = 1
*/

Console.WriteLine(a2 | b2); // Bitwise OR
/*
 * 0 | 0 = 0
 * 1 | 0 = 1
 * 0 | 1 = 1
 * 1 | 1 = 1
 * 0111 = 7
*/

Console.WriteLine(a2 ^ b2); // Bitwise XOR
/*
 * 0 ^ 0 = 0
 * 1 ^ 0 = 1
 * 0 ^ 1 = 1
 * 1 ^ 1 = 0
 * 0110 = 6
*/

Console.WriteLine($"Bitwise NOT: {~a2}"); // Bitwise NOT
/*
 * 0 -> 1
 * 1 -> 0
 * 0 -> 1
 * 1 -> 0
 * 1010 = -6
 * -8 + 2 = -6
*/


Console.WriteLine(a2 << b2); // Left Shift
Console.WriteLine(a2 >> b2); // Right Shift