// INFO: ADO.NET is a data access technology in C# (.NET) used to connect to databases, execute queries, and manipulate data.
// INFO: Connection to PostgreSQL
string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=usmonovdev777;Database=postgres";
using NpgsqlConnection connection = new(connectionString);
// connection.Open();
await connection.OpenAsync();
Console.WriteLine("Connected to PostgreSQL!");

// var todo = new Todo(connection);
// todo.Run();

var sqlLite = new SqlLite();
sqlLite.Select();

// INFO: SELECT Query (Read Data)

// string query = "SELECT id, name FROM users";
// using NpgsqlCommand cmd = new(query, connection);
// using NpgsqlDataReader reader = cmd.ExecuteReader();
// while (reader.Read())
// {
//   Console.WriteLine($"{reader["id"]} - {reader["name"]}");
// }

// INFO: INSERT Query

// string query = "INSERT INTO users(name, email) VALUES(@name, @email)";
// using NpgsqlCommand cmd = new(query, connection);
// cmd.Parameters.AddWithValue("@name", "Hello");
// cmd.Parameters.AddWithValue("@email", "Hello@gmail.com");
// int rows = cmd.ExecuteNonQuery();
// Console.WriteLine($"{rows} inserted");

// INFO: UPDATE

// string query = "UPDATE users SET name=@name WHERE id=@id";
// using NpgsqlCommand cmd = new(query, connection);
// cmd.Parameters.AddWithValue("@name", "Alex");
// cmd.Parameters.AddWithValue("@id", 1);
// cmd.ExecuteNonQuery();

// INFO: DELETE

// string query = "DELETE FROM users WHERE id=@id";
// using NpgsqlCommand cmd = new(query, connection);
// cmd.Parameters.AddWithValue("@id", 1);
// cmd.ExecuteNonQuery();


// INFO: Transaction

// using var tran = connection.BeginTransaction();
// try
// {
//     using var cmd = connection.CreateCommand();
//     cmd.Transaction = tran;
//     cmd.CommandText = "INSERT INTO users(name) VALUES('Test')";
//     cmd.ExecuteNonQuery();
//     tran.Commit();
// }
// catch
// {
//     tran.Rollback();
// }

// INFO: Async

// string query = "SELECT * FROM users";
// await using var cmd = new NpgsqlCommand(query, connection);
// await using var reader = await cmd.ExecuteReaderAsync();
//
// while (await reader.ReadAsync())
// {
//     Console.WriteLine(reader["name"]);
// }

// string query = "SELECT COUNT(*) FROM users";
// await using var cmd = new NpgsqlCommand(query, connection);
// int count = Convert.ToInt32(await cmd.ExecuteScalarAsync());
// Console.WriteLine($"Total users: {count}");


// INFO: Batch Insert (Multiple Records)

// var query = "INSERT INTO users(name, email) VALUES(@name, @email)";
// await using var cmd = new NpgsqlCommand(query, connection);
// cmd.Parameters.Add("@name", NpgsqlTypes.NpgsqlDbType.Text);
// cmd.Parameters.Add("@email", NpgsqlTypes.NpgsqlDbType.Text);
//
// for (int i = 0; i < 5; i++)
// {
//   cmd.Parameters["@name"].Value = $"Name{i}";
//   cmd.Parameters["@email"].Value = $"User{i}";
//
//   await cmd.ExecuteNonQueryAsync();
// }
//
