// null-coalescing operators
string str = null;
Console.WriteLine(str ?? "Unkown String");

// str ??= "new string";
// Console.WriteLine(str);

if (str is null)
{
  str = "Another way";
} 
Console.WriteLine(str);


string notNullStr = "hello";

notNullStr ??= "String is Null";
Console.WriteLine(notNullStr);
