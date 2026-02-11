//INFO: An enum (enumeration) is a value type that represents a fixed set of named constants.

using System.Runtime.InteropServices.Swift;

namespace Enums
{
  class Program
  {
    enum OrderStatus
    {
      Pending,
      Processing,
      Shipped,
      Delivered,
      Canceled
    }

    enum HttpStatus : short
    {
      OK = 200,
      NotFound = 404,
      ServerError = 500
    }

    [Flags]
    enum Permissions : byte
    {
      None = 0,
      Read = 1,     // 0001
      Write = 2,    // 0010
      Execute = 4,  // 0100
      All = Read | Write | Execute
    }

    static void Main(string[] args)
    {
      H("Basic Enum");
      OrderStatus status = OrderStatus.Shipped;
      Console.WriteLine("Status: {0}", status);
      Console.WriteLine($"Status int: {(int)OrderStatus.Canceled}");

      H("Enum with Custom Values");
      HttpStatus http = HttpStatus.NotFound;
      Console.WriteLine("{0} {1}", http, (short)http);

      H("Parsing Enum from String");
      if (Enum.TryParse("Delivered", out OrderStatus parsedStatus))
      {
        Console.WriteLine("Parsed: {0}", parsedStatus);
      }

      H("Converting int to Enum");
      int code = 3;
      if (Enum.IsDefined(typeof(OrderStatus), code))
      {
        OrderStatus fromInt = (OrderStatus)code;
        Console.WriteLine($"From int {code}: {fromInt}");
      }

      H("Flags Enum");
      Permissions userPermission = Permissions.Read | Permissions.Write;
      Console.WriteLine("User Permissions: {0}", userPermission);

      bool canRead = userPermission.HasFlag(Permissions.Read);
      bool canExecute = userPermission.HasFlag(Permissions.Execute);

      Console.WriteLine("Can Read {0}", canRead);
      Console.WriteLine("Can Execute {0}", canExecute);

      H("Switch with Enum");

      switch (status)
      {
        case OrderStatus.Pending:
          Console.WriteLine("Order is pending");
          break;
        case OrderStatus.Shipped:
          Console.WriteLine("Order is on the way");
          break;
        case OrderStatus.Delivered:
          Console.WriteLine("Order delivered");
          break;
        default:
          Console.WriteLine("Other status");
          break;
      }

      H("Bitwise Flags Check");
      userPermission |= Permissions.Execute; // Add Execute permission
      Console.WriteLine($"Updated Permissions: {userPermission}");
      userPermission &= ~Permissions.Write; // Remove Write
      Console.WriteLine($"After removing Write: {userPermission}"); // Read, Execute
    }

    static void H(string s)
    {
      string line = new('-', 20);
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine("{0} {1} {0}", line, s);
      Console.ResetColor();
    }
  }
}

