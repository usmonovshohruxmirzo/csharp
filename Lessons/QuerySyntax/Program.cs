List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };

var evenNumbers = from n in numbers
                where n % 2 == 0
                select n;

foreach (var num in evenNumbers)
{
  Console.WriteLine(num);
}
