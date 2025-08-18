bool flag = true;
Console.WriteLine(sizeof(bool));
Console.WriteLine(flag ? "C#" : "JAVASCRIPT");
Console.WriteLine(!flag);
Console.WriteLine(!!!flag);

// Short-Circuiting and Performance Considerations
bool CheckA()
{
    Console.WriteLine("Evaluating A...");
    return true;
}

bool CheckB()
{
    Console.WriteLine("Evaluating B...");
    return true;
}

if (CheckA() && CheckB())
{
    Console.WriteLine("Both are true!");
}

bool IsUserAdmin()
{
    Console.WriteLine("Checking Admin...");
    return false;
}

bool IsUserLoggedIn()
{
    Console.WriteLine("Checking Login...");
    return true;
}

// Short-circuiting: IsUserAdmin() returns false, so IsUserLoggedIn() is never called.
if (IsUserAdmin() && IsUserLoggedIn())
{
    Console.WriteLine("Access Granted");
}

Console.WriteLine(IsUserLoggedIn() || IsUserAdmin());

// Forcing Evaluation with & and |
Console.WriteLine("Bitwise & and |");
Console.WriteLine(true | false);
Console.WriteLine(false | true);
Console.WriteLine(true & false);
Console.WriteLine(false & true);

if (IsUserAdmin() & IsUserLoggedIn())
{
    Console.WriteLine("Access Granted");
}

if (IsUserAdmin() | IsUserLoggedIn())
{
    Console.WriteLine("Access Granted");
}

// XOR (^) – Exclusive OR

bool hasKey = true;
bool knowPassword = false;

if (hasKey ^ knowPassword)
{
    Console.WriteLine("Partial Access Granted");
} else
{
    Console.WriteLine("No Access or Full Access");
}

// Nullable Booleans (bool?) and Coalescing
bool? isFeatureEnabled = null;

if (isFeatureEnabled ?? false)
{
    Console.WriteLine("Feature is enabled");
}
else
{
    Console.WriteLine("Feature is disabled by default");
}

//  Lazy Evaluation with Lambda Expressions
bool LazyCheck (Func<bool> condition)
{
    return condition();
}

bool expensiveCheck()
{
    Console.WriteLine("Performing expensive check...");
    return false;
}

if (LazyCheck(() => expensiveCheck() && true))
{
    Console.WriteLine("Access Granted");
}


// Compound assignment

bool test = true;
test &= false; // test = test & false
Console.WriteLine(test);  // output: False

test |= true;
Console.WriteLine(test);  // output: True

test ^= false;
Console.WriteLine(test);  // output: True

// Operator precedence

/*
 * Logical negation operator !
 * Logical AND operator &
 * Logical exclusive OR operator ^
 * Logical OR operator |
 * Conditional logical AND operator &&
 * Conditional logical OR operator || 
*/

Console.WriteLine(false | false & true);
Console.WriteLine((true | false) & true);

bool Operand(string name, bool value)
{
    Console.WriteLine($"Operand {name} is evaluated.");
    return value;
}

//var byDefaultPrecedence = Operand("A", true) || Operand("B", true)

bool b1 = false;
bool b2 = false;
bool b3 = false;
Console.WriteLine("TASK:");
Console.WriteLine(b1 ^ (b2 | b3));
Console.WriteLine(!b1 & (!b2 & b3));
Console.WriteLine(b1 | !(b2 & b3));
Console.WriteLine(b1 ^ (!b2 | b3));
Console.WriteLine(b1 | (b2 & b3));