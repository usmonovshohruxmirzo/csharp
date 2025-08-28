// Filtering Methods ==========================
// Purpose: Select elements based on a condition.

// Filters elements based on a predicate.
Console.WriteLine("==== Where ====");
int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var evenNumbers = numbers.Where(n => n % 2 == 0);

foreach (int n in evenNumbers)
{
    Console.WriteLine(n);
}

// Filters elements of a specific type.
Console.WriteLine("==== OfType ====");
object[] items = { 1, "hello", 2.5, true, false };
var ints = items.OfType<int>();
foreach (int i in ints)
{
    Console.WriteLine(i);
}

// Projection Methods ==================
// Purpose: Transform each element into a new form.
//

Console.WriteLine("==== Select ====");
var squares = numbers.Select(n => n * n);
foreach (var s in squares)
{
    Console.WriteLine(s);
}

Console.WriteLine("==== SelectMany ====");
string[] words = { "hello", "world" };
var letters = words.SelectMany(w => w.ToCharArray());
foreach (var c in letters)
{
    Console.Write(c + " ");
}

var students = new[]
{
    new { Name = "Ali", Subjects = new[] { "Math", "Physics" } },
    new { Name = "Sara", Subjects = new[] { "Biology", "Chemistry" } }
};

var selectResult = students.Select(student => student.Subjects);
Console.WriteLine("Select Result:");
foreach (var subject in selectResult)
{
    Console.WriteLine($"[{string.Join(", ", subject)}]");
}

var selectManyResult = students.SelectMany(s => s.Subjects);
Console.WriteLine("\nSelectMany Result:");
foreach (var subject in selectManyResult)
{
    Console.WriteLine(subject);
}

// Ordering Methods =================
// Purpose: Sort elements.
Console.WriteLine();
Console.WriteLine("==== OrderBy ====");

var sorted = numbers.OrderBy(n => n);
foreach (var i in sorted)
{
    Console.Write(i);
}

Console.WriteLine();
Console.WriteLine("==== OrderByDescending ====");
var desc = numbers.OrderByDescending(n => n);
foreach (var i in desc)
{
    Console.Write(i);
}

// ThenBy / ThenByDescending: Secondary sorting.
Console.WriteLine("\n\n ==== ThenBy / ThenByDescending ====");

var people = new[]
{
  new { Name="Alice", Age=25 },
  new { Name="Bob", Age=25 },
  new { Name="Charlie", Age=30 },
  new { Name="David", Age=25 }
};

// Primary sort: Age ascending
// Secondary sort: Name ascending for people with same age
var sortedPeople = people.OrderBy(p => p.Age).ThenByDescending(p => p.Name);

foreach (var p in sortedPeople)
{
    Console.WriteLine("{0}, {1}", p.Name, p.Age);
}


// Grouping Methods =================
Console.WriteLine("\n\n ==== GroupBy ====");
var grouped = people.GroupBy(p => p.Age);
foreach (var group in grouped)
{
    Console.WriteLine($"Age: {group.Key}");
    foreach (var p in group) Console.WriteLine("- " + p.Name);
}



// Quantifiers ===============
// Purpose: Check conditions across elements.

Console.WriteLine("\n\n===== Any / All / Contains =====");
bool hasEven = numbers.Any(n => n % 2 == 0);
bool hasEvenAll = numbers.All(n => n % 2 == 0);
bool hasThree = numbers.Contains(3);

Console.WriteLine(hasEven);
Console.WriteLine(hasEvenAll);
Console.WriteLine(hasThree);

// Element Operators
// Purpose: Retrieve elements.
Console.WriteLine("\n\n==== First / FirstOrDefault =====");

var firstEven = numbers.First(n => n % 2 == 0);
Console.WriteLine(firstEven);

var firstOrZero = numbers.FirstOrDefault(n => n > 10);
var firstOrZero2 = numbers.FirstOrDefault(n => n > 5);
Console.WriteLine(firstOrZero);
Console.WriteLine(firstOrZero2);


Console.WriteLine("\n\n==== Last / LastOrDefault =====");
var lastEven = numbers.Last(n => n % 2 == 0);
var lastOrZero = numbers.LastOrDefault(n => n > 10);
Console.WriteLine(lastEven);
Console.WriteLine(lastOrZero);


Console.WriteLine("\n\n==== Single / singleOrDefault =====");
var single = new int[] { 42 }.Single(); // 42
var singleOrDefault = new int[] { }.SingleOrDefault(); // 42
Console.WriteLine(single);
Console.WriteLine(singleOrDefault);


Console.WriteLine("\n\n==== ElementAt / ElementAtOrDefault =====");
var secondEl = numbers.ElementAt(1);
var elOrDefault = numbers.ElementAtOrDefault(100);
Console.WriteLine(secondEl);
Console.WriteLine(elOrDefault);


// Aggregation Methods
// Purpose: Combine elements into a single value.

Console.WriteLine("\n\n==== Count / Sum / Average / Aggregate / Min / Max =====");
int total = numbers.Count();
Console.WriteLine(total);

int sum = numbers.Sum();
Console.WriteLine(sum);

double avg = numbers.Average();
Console.WriteLine(avg);

// Aggregate: Custom aggregation.
int product = numbers.Aggregate((acc, n) => acc * n);
Console.WriteLine(product);

int maxNum = numbers.Max();
Console.WriteLine(maxNum);

int minNum = numbers.Min();
Console.WriteLine(minNum);



// Set Operations ===================
// Purpose: Work with distinct elements or combine sequences.

Console.WriteLine("==== Distinct / Union / Intersect / Except ====");
int[] nums = { 1, 1, 2, 2, 3, 3 };
var distinct = nums.Distinct();
foreach (var n in distinct)
{
    Console.Write(n + " ");
}

Console.WriteLine();
int[] a = { 1, 2 };
int[] b = { 2, 3, 4, 5 };
var union = a.Union(b);
foreach (var n in union)
{
    Console.Write(n + " ");
}

Console.WriteLine();
var intersect = a.Intersect(b);
foreach (var n in intersect)
{
    Console.Write(n + " ");
}

Console.WriteLine();
var except = a.Except(b);
foreach (var n in except)
{
    Console.Write(n + " ");
}

// Conversion Methods ==========================

var list = numbers.ToList();
var array = list.ToArray();
var dict = people.ToDictionary(p => p.Name, p => p.Age);


// Joining Methods ========

Console.WriteLine("==== Join ====");
var orders = new[] { new { Id = 1, CustomerId = 1 }, new { Id = 2, CustomerId = 2 } };
var customers = new[] { new { Id = 1, Name = "Alice" }, new { Id = 2, Name = "Alex" } };
var join = orders.Join(customers, o => o.CustomerId, c => c.Id, (o, c) => new { o.Id, c.Name });
foreach (var c in join)
{
    Console.WriteLine("Id: {0}, Name: {1}", c.Id, c.Name);
}


// Partitioning Methods ===============

Console.WriteLine("==== Take / Skip ====");
var first3 = numbers.Take(3);
foreach (int n in first3)
{
    Console.WriteLine(n);
}

var skip3 = numbers.Skip(3);
foreach (int n in skip3)
{
    Console.WriteLine(n);
}

// Miscellaneous =================

Console.WriteLine("==== Take / Skip ====");

var rev = numbers.Reverse();
foreach (var n in rev)
{
    Console.Write(n + " ");
}

Console.WriteLine();
Console.WriteLine();
var combined = a.Concat(b);
foreach (var n in combined)
{
    Console.Write(n + " ");
}

Console.WriteLine();
var empty = new int[] { };
var result = empty.DefaultIfEmpty(100);
foreach (var num in result)
{
    Console.WriteLine(num);
}
