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