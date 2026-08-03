using Indexers;

var clsIndexer = new ClassIndexer();

Console.WriteLine(clsIndexer[0]);
Console.WriteLine(clsIndexer["1"]);


int[] nums = [1, 2, 3, 4, 5, 8, 9, 7, 11, 2, 3, 4, 8, 6];
Range rng = 1..5;
Console.WriteLine(string.Join(", ", nums[rng]));

