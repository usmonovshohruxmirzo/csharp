namespace Arrays
{
   public static class Program
    {
        public static void Main()
        {
            //Arrays
            int[] numbers = new int[10]; // All values are 0
            string[] messages = new string[10]; // All values are null.

            int[] array1 = new int[5];

            int[] array2 = [1, 2, 3, 4, 5, 6];

            int[,] multiDimensionalArray1 = new int[2, 3]; // 2 rows, 3 columns

            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            int[][] jaggedArray = new int[6][];
            jaggedArray[0] = [1, 2, 3, 4];

            // Collection expressions:
            //int[] array = [1, 2, 3, 4, 5, 6];
            // Alternative syntax:
            //int[] array2 = { 1, 2, 3, 4, 5, 6 };

            //Single-dimensional arrays
            int[] array = new int[5];
            string[] weekDays = ["Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"];
            Console.WriteLine(weekDays[0]);

            //Pass single-dimensional arrays as arguments
            DisplayArray(weekDays);
            Console.WriteLine();

            ChangeArray(weekDays);
            DisplayArray(weekDays);
            Console.WriteLine();

            ChangeArrayElements(weekDays);
            DisplayArray(weekDays);

            // Multidimensional arrays
            int[,] array2DDeclaration = new int[4, 2]; 
            int[,,] array3DDeclaration = new int[4, 2, 3];

            int[,] array2DInitialization = { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } };
            int[,,] array3D = new int[,,]
            {
                {
                    { 1, 2, 3 },     // array3D[0,0,x]
                    { 4, 5, 6 }      // array3D[0,1,x]
                },
                {
                    { 7, 8, 9 },     // array3D[1,0,x]
                    { 10, 11, 12 }   // array3D[1,1,x]
                }
            };


            System.Console.WriteLine(array2DInitialization[1, 0]);
            System.Console.WriteLine(array3D[1, 1, 1]);
            Console.WriteLine(array3D.Rank);

            // Getting the total count of elements or the length of a given dimension.
            var allLength = array3D.Length;
            var total = 1;
            for (int i = 0; i < array3D.Rank; i++)
            {
                total *= array3D.GetLength(i);
            }
            System.Console.WriteLine($"{allLength} equals {total}");

            int[,] numbers2D = { { 9, 99 }, { 3, 33 }, { 5, 55 } };
            foreach(int i in numbers2D)
            {
                System.Console.Write($"{i} ");
            }

            Console.WriteLine();
            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        Console.Write($"{array3D[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            // Pass multidimensional arrays as arguments
            Print2DArray(new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } });

            // Jagged arrays
            int[][] jaddedArray1 = new int[3][];
            jaddedArray1[0] = [1, 3, 5, 7, 9];
            jaddedArray1[1] = [0, 2, 4, 6];
            jaddedArray1[2] = [11, 22];

            int[][] jaggedArray2 =
            [
                [1, 3, 5, 7, 9],
                [0, 2, 4, 6],
                [11, 22]
            ];
            jaggedArray2[0][1] = 77;
            Console.WriteLine(jaggedArray2[0][1]);

            int[][,] jaddedArray3 =
            [
                new int[,] { {1,3}, {5,7} },
                new int[,] { {0,2}, {4,6}, {8,10} },
                new int[,] { {11,22}, {99,88}, {0,9} }
            ];
            Console.WriteLine("{0}", jaddedArray3[0][0, 1]);
            Console.WriteLine(jaddedArray3.Length);

            int[][] arr = new int[2][];
            arr[0] = [1, 3, 5, 7, 9];
            arr[1] = [2, 4, 6, 8];

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Element({0}): ", i);
                
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write("{0}{1}", arr[i][j], j == (arr[i].Length - 1) ? "" : " ");
                }

                Console.WriteLine();
            }

            // Implicitly typed arrays

            int[] ImplicitlyA = new[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine(string.Join(", ", ImplicitlyA));

            var ImplicitlyB = new[] { "c#", "c", "rust" };
            Console.WriteLine(string.Join(", ", ImplicitlyB));

            int[][] c =
            [
                [1,2,3,4],
                [5,6,7,8],
            ];

            for (int k = 0; k < c.Length; k++)
            {
                for (int j = 0; j < c.Length; j++)
                {
                    Console.WriteLine($"Element at c[{k}][{j}] is: {c[k][j]}");
                }
            }

            string[][] d =
            [
                ["Luca", "Mads", "Luke", "Dinesh"],
                ["Karen", "Suma", "Frances"]
            ];

            int idx = 0;
            foreach (var subArray in d)
            {
                int j = 0;
                foreach (var element in subArray)
                {
                    Console.WriteLine($"Element at d[{idx}][{j}] is: {element}");
                    j++;
                }
                idx++;
            }

            var contacts = new[]
            {
                new
                {
                    Name = "Eugene Zabokritski",
                    PhoneNumbers = new[] { "206-555-0108", "425-555-0001" }
                },
                new
                {
                    Name = "Hanying Feng",
                    PhoneNumbers = new[] { "650-555-0199" }
                }
            };

            foreach (var contact in contacts)
            {
                Console.WriteLine($"Name: {contact.Name}");
                Console.WriteLine("Phone Numbers:");
                foreach(var phone in contact.PhoneNumbers)
                {
                    Console.WriteLine($" - {phone}");
                }
            }
        }

        public static void DisplayArray(string[] arr) => Console.WriteLine(string.Join(" ", arr));

        public static void ChangeArray(string[] arr) => Array.Reverse(arr);

        public static void ChangeArrayElements(string[] arr)
        {
            arr[0] = "Changed";
            arr[1] = "Changed";
            arr[2] = "Changed";
        }

        public static void Print2DArray(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Console.WriteLine($"Element({i}, {j}) = {arr[i, j]}");
                }
            }
        }

    }
}