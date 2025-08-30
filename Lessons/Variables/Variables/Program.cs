// Declaring Variables
// <datatype> <variable_name> = <value>;

// ================= Value Types (Stored in Stack)

int x = 10; // Stores integers
Console.WriteLine($"value: {x}, type: {x.GetType().Name}");

double pi = 3.15; // Stores floating-point numbers
Console.WriteLine($"value: {pi}, type: {pi.GetType().Name}");

char letter = 'A'; // Stores single characters
Console.WriteLine($"value: {letter}, type: {letter.GetType().Name}");

bool isReady = true; // Stores true/false values
Console.WriteLine($"value: {isReady}, type: {isReady.GetType().Name}");

float price = 5.99f; // Stores floating-point numbers with less precision
Console.WriteLine($"value: {price}, type: {price.GetType().Name}");

long distance = 9999999999L; //  Stores large integers
Console.WriteLine($"value: {distance}, type: {distance.GetType().Name}");

byte age = 255; // Stores small integer values (0 to 255)
Console.WriteLine($"value {age}, type: {age.GetType().Name}");

short level = 32767; // Stores small integers (-32,768 to 32,767)
Console.WriteLine($"value: {level}, type: {level.GetType().Name}");


// ================= Reference Types (Stored in Heap)
string message = "Hello C#"; // Stores text
Console.WriteLine($"value: {message}, type: {message.GetType().Name}");

object obj = 42; // Can store any data type
Console.WriteLine($"value: {obj}, type: {obj.GetType().Name}");

dynamic data = 10; // Allows dynamic typing (value can change types at runtime)
Console.WriteLine(data);
data = "Hello";
Console.WriteLine(data);

// Nullable Types
int? nullableInt = null; // Can hold null or integer value
Console.WriteLine($"value: {nullableInt}, type: {nullableInt?.GetType()?.Name ?? "Null"}");

// Rules for Naming Variables

int age1 = 30;       // Valid
string _name = "Tom"; // Valid
//double 2price = 15.5; // Invalid (Cannot start with a number)
int @class = 10;    // Valid (Using @ to escape keywords)

Console.WriteLine($"""{age1} {_name} {@class}""");

// Declaring  implicit variable
var vx = "Hello";
var vz = 1212;
Console.WriteLine("{0}, {1}", vx, vz);

// Declaring array of values
int[] vals = new int[5];
string[] strs = { "one", "two", "three" };

Console.WriteLine("{0}, {1}, {2}", x, vx, vz);

// null (no value)
object obj1 = null;
Console.WriteLine(obj1);

// implicit conversion between types
long bigNum;
bigNum = vz;

// explicit conversion
float vz_to_f = (float)vz;
Console.WriteLine("{0}", vz_to_f);

float fnum = 5.8f;
int fnum_to_int = (int)fnum;
Console.WriteLine(fnum_to_int);
