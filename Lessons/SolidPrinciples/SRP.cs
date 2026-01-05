public class SRP
{
    public static void Run()
    {
        Console.WriteLine("SRP");
    }
}

class UserService
{
    public void Register(string email)
    {
        // business logic
        Console.WriteLine("User registered");

        // logging
        File.WriteAllText("log.txt", email);

        // saving to database
        SaveToDatabase(email);
    }

    void SaveToDatabase(string email) { }
}
