//namespace IterationStatements
//{
//    public class Program
//    {
//        static void Main()
//        {
//            Console.WriteLine("Print numbers from 1 to 5");
//            for (int i = 1; i <= 5; i++)
//            {
//                Console.WriteLine("Number: " + i);
//            }

//            Console.WriteLine("Reverse loop");
//            for (int i = 5; i >= 1; i--)
//            {
//                Console.WriteLine(i);
//            }

//            // while loop - Use while when you don’t know how many times to loop in advance.
//            int num = 0;
//            while (num <= 5)
//            {
//                Console.WriteLine("Count: " + num);
//                num++;
//            }

//            //int option;

//            //do
//            //{
//            //    Console.WriteLine("1. Say Hello");
//            //    Console.WriteLine("0. Exit");
//            //    option = Convert.ToInt32(Console.ReadLine());

//            //    if (option == 1)
//            //    {
//            //        Console.WriteLine("Hello!");
//            //    }

//            //} while (option != 0);

//            // Code block executes at least once, even if condition is false.
//            /*
//             * Visual Flow:
//                ✅ Code runs first (do { ... })
//                ❓ Then it checks the condition (while (condition))
//             */
//            int number = 10;
//            do
//            {
//                Console.WriteLine("This runs once, even if condition is false.");
//            } while (number < 5);

//            // foreach Loop

//            string[] cars = { "BMW", "TESLA", "FERRARI" };
//            foreach (string car in cars)
//            {
//                Console.Write(car.ToLower() + " ");
//            }


//            // break, continue, goto in loops

//            // break: Exit the loop
//            Console.WriteLine();
//            Console.WriteLine("break");
//            for (int i = 0; i <= 10; i++)
//            {
//                if (i == 5) break;
//                Console.WriteLine(i);
//            }

//            // continue: Skip current iteration
//            Console.WriteLine();
//            Console.WriteLine("continue");
//            for (int i = 0; i <= 10; i++)
//            {
//                if (i == 5) continue;
//                Console.WriteLine(i);
//            }

//            // goto: Not recommended (but used in rare cases)
//            Console.WriteLine();
//            Console.WriteLine("goto");
//            int x = 1;
//        start:
//            Console.WriteLine(x);
//            x++;
//            if (x <= 5) goto start;

//            // nested loop
//            Console.WriteLine();
//            Console.WriteLine("nested loops");
//            for (int i = 0; i < 10; i++)
//            {
//                for (int j = 0; j < 10;j++)
//                {
//                    Console.WriteLine($"{i} * {i} = {i * j}");
//                }
//            }

//            // infinite loop
//            //while (true)
//            //{
//            //    Console.WriteLine("Press 'p' to quit");
//            //    if (Console.ReadKey().KeyChar == 'q')
//            //    {
//            //        break;
//            //    }
//            //}

//            // Loop with List<T>
//            List<int> nums = new List<int> { 1, 2, 3, 4, 5 };
//            foreach(int n in nums)
//            {
//                Console.WriteLine(n);
//            }

//        }
//    }
//}

    using System;

namespace IterationStatements
{
    class Program
    {
        static void Main()
        {
            var random = new Random();
            int target = random.Next(0, 101), attempts = 0, guess;
            do
            {
                Console.Write("Guess: ");
                attempts++;
                while (!int.TryParse(Console.ReadLine(), out guess) || guess < 0 || guess > 100) Console.Write("Valid number (0-100): ");
                Console.WriteLine(guess > target ? "Too high" : guess < target ? "Too low" : $"Correct, Attempts: {attempts}");
            }
            while (guess != target);
        }
    }
}
