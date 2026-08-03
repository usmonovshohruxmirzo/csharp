using System.Linq.Expressions;

Expression<Func<int, int, int>> expr = (a, b) => a + b;

Console.WriteLine(expr);
Console.WriteLine(expr.Parameters[0]);
Console.WriteLine(expr.Parameters[1]);

var complied = expr.Compile();
Console.WriteLine(complied(10,20));
