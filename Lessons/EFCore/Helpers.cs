class Helpers
{
  public static string ReadString(string prompt)
  {
    while (true)
    {
      Console.WriteLine(prompt);
      var input = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(input))
      {
        return input.Trim();
      }
      Console.WriteLine("Input cannot be empty.");
    }
  }

  public static int ReadInt(string prompt)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = Console.ReadLine();
      if (int.TryParse(input, out var value))
      {
        return value;
      }
      Console.WriteLine("Invalid number. Please try again.");
    }
  }
}
