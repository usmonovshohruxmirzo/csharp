using Microsoft.Data.Sqlite;

class SqlLite
{
  private readonly string _connectionString = "Data Source=/home/usmonovdev/usmonovdev";
  private readonly SqliteConnection _connection = new();

  public SqlLite()
  {
    _connection = new SqliteConnection(_connectionString);
    _connection.Open();
    Console.WriteLine("Connected to SqlLite!");
  }

  public void Select()
  {
    var cmd = _connection.CreateCommand();
    cmd.CommandText = "SELECT * FROM users;";

    using var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
      int id = reader.GetInt32(0);
      string first_name = reader.GetString(1);
      string last_name = reader.GetString(2);
      int age = reader.GetInt32(3);
      string email = reader.GetString(4);
      string address = reader.GetString(5);

      Console.WriteLine($"[{id}] {first_name}, {last_name}, {age}, {email}, {address}");
    }
  }

  public void Insert()
  {
    var cmd = _connection.CreateCommand();
    cmd.CommandText = @"
      INSERT INTO users(id, FirstName, LastName, Age, Email, Address)
      VALUES($id, $FirstName, $LastName, $Age, $Email, $Address);
    ";

    cmd.Parameters.AddWithValue("$id", 2);
    cmd.Parameters.AddWithValue("$FirstName", "Alex");
    cmd.Parameters.AddWithValue("$LastName", "Johnson");
    cmd.Parameters.AddWithValue("$Age", 20);
    cmd.Parameters.AddWithValue("$Email", "alex@johnson.com");
    cmd.Parameters.AddWithValue("$Address", "NYC");

    cmd.ExecuteNonQuery();
  }
}
