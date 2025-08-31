void DisplayWeatherReport(double tempInCelsius)
{
    if (tempInCelsius < 20.0)
    {
        Console.WriteLine("Cold.");
    }
    else
    {
        Console.WriteLine("Perfect!");
    }
}
DisplayWeatherReport(15.0);  // Output: Cold.
DisplayWeatherReport(24.0);  // Output: Perfect!

void DisplayMeasurement(double value)
{
    if (value < 0 || value > 100)
    {
        Console.Write("Warning: not acceptable value! ");
    }

    Console.WriteLine($"The measurement value is {value}");
}
DisplayMeasurement(-3);
DisplayMeasurement(45);

void DisplayCharacter(char ch)
{
    if (char.IsUpper(ch))
    {
        Console.WriteLine($"An uppercase letter: {ch}");
    }
    else if (char.IsLower(ch))
    {
        Console.WriteLine($"A lowercase letter: {ch}");
    }
    else if (char.IsDigit(ch))
    {
        Console.WriteLine($"A digit: {ch}");
    }
    else
    {
        Console.WriteLine($"Not alphanumeric character: {ch}");
    }
}

DisplayCharacter('A');
DisplayCharacter('v');
DisplayCharacter('8');

int theVal = 10;
Console.WriteLine(theVal < 50 ? "theVal is small" : "theVal is big");

//  INFO: SWITCH CASE
void DisplayMeasurement_Switch(double measurement)
{
    switch (measurement)
    {
        case < 0.0:
            Console.WriteLine($"Measured value is {measurement}; too low.");
            break;
        case > 15.0:
            Console.WriteLine($"Measured value is {measurement}; too high.");
            break;
        case double.NaN:
            Console.WriteLine("Failed measurement.");
            break;
        default:
            Console.WriteLine($"Measured value is {measurement}.");
            break;
    }
}
DisplayMeasurement_Switch(-4);
DisplayMeasurement_Switch(5);
DisplayMeasurement_Switch(30);
DisplayMeasurement_Switch(double.NaN);

void DisplayMeasurement_Switch2(int measurement)
{
    switch (measurement)
    {
        case < 0:
        case > 100:
            Console.WriteLine($"Measured value is {measurement}; out of an acceptable range.");
            break;

        default:
            Console.WriteLine($"Measured value is {measurement}.");
            break;
    }
}
DisplayMeasurement_Switch2(-4);
DisplayMeasurement_Switch2(50);
DisplayMeasurement_Switch2(132);

// Case guards
void DisplayMeasurements_Switch3(int a, int b)
{
    switch((a, b))
    {
        case ( > 0, > 0) when a == b:
            Console.WriteLine($"Both measurements are valid and equal to {a}.");
            break;
        case ( > 0, > 0):
            Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
            break;
        case ( < 0, > 0):
            Console.WriteLine($"First measurement is {a}, second measurement is {b}.");
            break;
        default:
            Console.WriteLine("One or both measurements are not valid.");
            break;
    }
}

DisplayMeasurements_Switch3(3, 4);
DisplayMeasurements_Switch3(5, 5);
DisplayMeasurements_Switch3(-5, 5);

// Pattern matching - the is and switch expressions, and operators and, or, and not in patterns

// Pattern Matching with is Operator
object value = 42;

if (value is int number)
{
    Console.WriteLine($"The number is {number}.");
}

int x = 10;

if (x is > 0 and < 100)
{
    Console.WriteLine("x is between 1 and 99.");
}

// Pattern Matching in switch Expressions
string GetCategory(object input) => input switch
{
    int i when i > 0 => "Positive Integer",
    int i when i < 0 => "Negative Integer",
    double d => "Floating-point number",
    string s => $"String: {s}",
    null => "Null value",
    _ => "Unkown type"
};

Console.WriteLine(GetCategory("Hello"));

// Using Tuples in switch
string GetQuadrant(int x, int y) => (x, y) switch
{
    ( > 0, > 0) => "First Quadrant",
    ( < 0, > 0) => "Second Quadrant",
    ( < 0, < 0) => "Third Quadrant",
    ( > 0, < 0) => "Fourth Quadrant",
    (0, 0) => "Origin",
    _ => "On an axis"
};

Console.WriteLine(GetQuadrant(3, 4)); 
Console.WriteLine(GetQuadrant(-5, 6));
Console.WriteLine(GetQuadrant(0, 0));

// Logical Operators in Pattern Matching (and, or, not)
string DescribeNumber(int n) => n switch
{
    > 0 and < 10 => "Single-digit positive number",
    >= 10 and < 100 => "Two-digit positive number",
    _ => "Other number"
};
Console.WriteLine(DescribeNumber(7));
Console.WriteLine(DescribeNumber(42));
Console.WriteLine(DescribeNumber(100));

string GetTemperatureCategory(double temp) => temp switch
{
    < 0 or > 40 => "Extreme temperature",
    >= 0 and <= 10 => "Cold",
    > 10 and <= 30 => "Mild",
    _ => "Warm"
};

Console.WriteLine(GetTemperatureCategory(-5));
Console.WriteLine(GetTemperatureCategory(8));
Console.WriteLine(GetTemperatureCategory(22));
Console.WriteLine(GetTemperatureCategory(45));

