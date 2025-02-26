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

nint i = 10000; // Native Integer, Signed
nuint j = 10000; // Native Unsigned Integer

int x = 100;
long y = x;
nint z = x;

/*
Why Use nint and nuint?
- Performance Optimized → Matches the CPU’s native word size.
- Pointer Arithmetic → Used when working with low-level memory operations.
- Platform-Specific Behavior → Adapts to 32-bit or 64-bit environments automatically. 
*/

Console.WriteLine($"{a}, {a.GetType().Name}");
Console.WriteLine($"{b}, {b.GetType().Name}");
Console.WriteLine($"{c}, {c.GetType().Name}");
Console.WriteLine($"{d}, {d.GetType().Name}");
Console.WriteLine($"{e}, {e.GetType().Name}");
Console.WriteLine($"{f}, {f.GetType().Name}");
Console.WriteLine($"{g}, {g.GetType().Name}");
Console.WriteLine($"{h}, {h.GetType().Name}");
Console.WriteLine($"{i}, {i.GetType().Name}");
Console.WriteLine($"{j}, {j.GetType().Name}");


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
/*
 * << adds 0 from right side of binary
 * 5 = 00000101
 * 5 << 3
 * 00101000 = 40
*/

Console.WriteLine(a2 >> b2); // Right Shift
/*
 * >> adds 0 from left side of binary
 * 5 = 00000000
 * 5 >> 3
 * 00000000 = 0
*/

Console.WriteLine("Right Shift >>");
Console.WriteLine(5 >> 2);
Console.WriteLine(-5 >> -2);
Console.WriteLine(-5 >> 2);
Console.WriteLine(5 >> -2);

Console.WriteLine("Left Shift <<");
Console.WriteLine(5 << 2);
Console.WriteLine(-5 << -2);
Console.WriteLine(-5 << 2);
Console.WriteLine(5 << -2);


int al = 2100000000;
int bl = 2100000000;
long cl = al + bl;
Console.WriteLine(cl);

/*
Overflow happens when a number is too large to fit in a given data type.
🔹 int in C# is 32-bit, meaning it can store values from -2,147,483,648 to 2,147,483,647.
🔹 4200000000 is too big for int, so it wraps around using two’s complement, resulting in -94967296 instead. 
*/
// The two’s complement representation of 4200000000 (in a 32-bit signed integer) is -94967296.

int al2 = 2100000000;
int bl2 = 2100000000;
long cl2 = (long)al2 + (long)bl2;
Console.WriteLine(cl2);

int al3 = 2100000000;
int bl3 = 2100000000;
long cl3 = al3 + (long)bl3;
Console.WriteLine(cl3);

Console.WriteLine(int.MaxValue);
Console.WriteLine(int.MinValue);

System.UInt32 number = uint.MinValue;

uint num = 0x1234u; // The u suffix in 0x1234u means the number is explicitly an unsigned integer (uint)

Console.WriteLine(num);