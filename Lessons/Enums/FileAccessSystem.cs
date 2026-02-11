namespace FileAccessSystem
{

  [Flags]
  enum FilePermission
  {
    Read = 1,
    Write = 2,
    Execute = 4,
    Delete = 8,
    Share = 16
  }
  public class FileAccessSystem
  {

    public static void Run()
    {
      User user = new User("Alice");
      Console.WriteLine("Before AddPermission:");
      Console.WriteLine("Permissions: {0}", user.ListPermissions());

      Console.WriteLine("After AddPermission:");
      user.AddPermission(FilePermission.Read | FilePermission.Write);
      Console.WriteLine("Permissions: {0}", user.ListPermissions());

      Console.WriteLine("Has Permission: {0}", user.HasPermission(FilePermission.Execute));

      Console.WriteLine("After RemovePermission:");
      user.RemovePermission(FilePermission.Write);

      Console.WriteLine("Permissions: {0}", user.ListPermissions());
    }
  }

  class User
  {
    public string Name { get; set; }
    public FilePermission permissions;

    public User(string name)
    {
      Name = name;
    }

    public void AddPermission(FilePermission permission)
    {
      permissions |= permission;
    }

    public void RemovePermission(FilePermission permission)
    {
      permissions &= ~permission;
    }

    public bool HasPermission(FilePermission permission)
    {
      return permissions.HasFlag(permission);
    }

    public FilePermission ListPermissions()
    {
      return permissions;
    }
  }
}
