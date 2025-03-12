
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