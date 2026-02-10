#pragma warning disable
// #define SECURE
#define INSECURE

using System;
using System.Reflection;

#if INSECURE

class Human
{
    private string secret = "MySecret";

    private void ShowSecret()
    {
        Console.WriteLine($"Secret: {secret}");
    }
}

class BypassingAccessModifiers
{
    public static void Run()
    {
        Human p = new Human();

        FieldInfo field = typeof(Human)
            .GetField("secret", BindingFlags.NonPublic | BindingFlags.Instance);

        Console.WriteLine($"Private field value: {field.GetValue(p)}");

        field.SetValue(p, "NewSecret");
        Console.WriteLine($"Modified private field value: {field.GetValue(p)}");

        MethodInfo method = typeof(Human)
            .GetMethod("ShowSecret", BindingFlags.NonPublic | BindingFlags.Instance);

        method.Invoke(p, null);
    }
}

#endif

#if SECURE

#region SecureVersion

sealed class HumanSecure
{
    private readonly Func<string> _secretProvider;

    public HumanSecure()
    {
        _secretProvider = GetSecretSecurely;
    }

    private void ShowSecret()
    {
        if (!IsAuthorized())
            throw new UnauthorizedAccessException("Access denied.");

        Console.WriteLine($"Secret: {_secretProvider()}");
    }

    private bool IsAuthorized()
    {
        return false; 
    }

    private string GetSecretSecurely()
    {
        return "SECURE_SECRET";
    }
}

class BypassingAccessModifiersSecure
{
    public static void Run()
    {
        HumanSecure p = new HumanSecure();

        MethodInfo method = typeof(HumanSecure)
            .GetMethod("ShowSecret", BindingFlags.NonPublic | BindingFlags.Instance);

        try
        {
            method.Invoke(p, null);
        }
        catch (TargetInvocationException ex)
        {
            Console.WriteLine(ex.InnerException?.Message);
        }
    }
}

#endregion

#endif
