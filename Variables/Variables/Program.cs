// Declaring Variables
// type variableName = value;

int age = 10;
Console.WriteLine(age);

// Data types
int myNum = 20;
double myDoubleNum = 5.99D;
float pi = 3.14f;
bool isAlive = true;
string text = "Hello C#";

Console.WriteLine($"value: {myNum} type: {myNum.GetType().Name}");
Console.WriteLine($"value: {myDoubleNum} type: {myDoubleNum.GetType().Name}");
Console.WriteLine($"value: {pi} type: {pi.GetType().Name}");
Console.WriteLine($"value: {isAlive} type: {isAlive.GetType().Name}");
Console.WriteLine($"value: {text} type: {text.GetType().Name}");

// Type type = text.GetType();
// Console.WriteLine(type);

int[] numList = {1,2,3,4};
string[] cars = {"BMW", "TESLA", "FERRARI"};
Console.WriteLine($"value: {numList} type: {numList.GetType().Name}, value: {cars} type: {cars.GetType().Name}");

// Constants and Read-Only Variables
const double Pi = 3.14159; // Compile-time constant
// readonly DateTime startTime = DateTime.Now; // Runtime constant

// Nullable Variables
int? nullableInt = null;