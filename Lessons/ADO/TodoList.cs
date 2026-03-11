class Todo(NpgsqlConnection connection)
{
  public void Run()
  {
    bool exit = false;
    var commands = new Dictionary<string, Action>
    {
      ["add"] = () =>
      {
        int id = ReadInt("ID: ");
        string title = ReadString("TITLE: ");
        string description = ReadString("DESCRIPTION: ");
        Add(id, title, description);
      },
      ["update"] = () =>
      {
        var id = ReadInt("ID: ");
        var title = ReadString("NEW TITLE: ");
        var description = ReadString("NEW DESCRIPTION: ");
        Update(id, title, description);
      },
      ["delete"] = () =>
      {
        var id = ReadInt("ID: ");
        Delete(id);
      },
      ["todos"] = Display,
      ["exit"] = () => exit = true
    };

    while (!exit)
    {
      Console.Write("> Enter Option: ");
      var option = (Console.ReadLine() ?? string.Empty).Trim().ToLower();
      if (commands.TryGetValue(option, out var action))
      {
        action();
      }
      else
      {
        Console.WriteLine("Unknown command.");
      }
    }
  }
  public void Add(int id, string title, string description)
  {
    try
    {
      string query = @"
        INSERT INTO todos(id, title, description) 
        VALUES(@id, @title, @description)
      ";
      using NpgsqlCommand cmd = new(query, connection);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.Parameters.AddWithValue("@title", title);
      cmd.Parameters.AddWithValue("@description", description);

      int rows = cmd.ExecuteNonQuery();
      Console.WriteLine($"{rows} INSERTED");
    }
    catch (PostgresException ex)
    {
      Console.WriteLine(ex.Message);
    }
  }

  public void Delete(int id)
  {
    try
    {
      string query = "DELETE FROM todos WHERE id = @id";
      using NpgsqlCommand cmd = new(query, connection);
      cmd.Parameters.AddWithValue("@id", id);

      int rows = cmd.ExecuteNonQuery();
      Console.WriteLine($"{rows} DELETED");
    }
    catch (PostgresException ex)
    {
      Console.WriteLine(ex.Message);
    }
  }

  public void Update(int id, string title, string description)
  {
    try
    {
      string query = @"
        UPDATE todos 
        SET title=@title, description=@description 
        WHERE id = @id
      ";
      using NpgsqlCommand cmd = new(query, connection);
      cmd.Parameters.AddWithValue("@id", id);
      cmd.Parameters.AddWithValue("@title", title);
      cmd.Parameters.AddWithValue("@description", description);

      int rows = cmd.ExecuteNonQuery();
      Console.WriteLine($"{rows} UPDATED");
    }
    catch (PostgresException ex)
    {
      Console.WriteLine(ex.Message);
    }
  }

  public void Display()
  {
    string query = "SELECT * FROM todos";
    using var cmd = new NpgsqlCommand(query, connection);
    using NpgsqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("{0}) {1}, {2}", reader["id"], reader["title"], reader["description"]);
      Console.ResetColor();
    }
  }

  private static int ReadInt(string prompt)
  {
    while (true)
    {
      Console.Write(prompt);
      if (int.TryParse(Console.ReadLine(), out var value))
      {
        return value;
      }
      Console.WriteLine("Invalid number. Please try again.");
    }
  }

  private static string ReadString(string prompt)
  {
    while (true)
    {
      Console.Write(prompt);
      var input = Console.ReadLine();
      if (!string.IsNullOrWhiteSpace(input))
      {
        return input.Trim();
      }
      Console.WriteLine("Input cannot be empty.");
    }
  }
}
