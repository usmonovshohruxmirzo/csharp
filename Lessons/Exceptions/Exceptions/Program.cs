namespace Exceptions
{
    public static class Program
    {
        public static void Main()
        {
            HandleDivisionByZero();
            //HandleExceptionWithFilter();
            // CustomExceptions();
        }

        static void HandleDivisionByZero()
        {
            int x = 1002;
            int y = 0;
            int result;

            try
            {
                if (x > 1000)
                {
                    throw new ArgumentOutOfRangeException("x", "x has to be 1000");
                }

                result = x / y;
                Console.WriteLine($"The result is: {0}", result);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Whoops!");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("Sorry, 1000 is the limit");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Done");
            }
        }

        static void HandleExceptionWithFilter()
        {
            try
            {
                throw new ArgumentException("Invalid input", "paramName");
            }
            catch (ArgumentException e) when (e.ParamName == "paramName")
            {
                Console.WriteLine("Caught specific ArgumentException for paramName.");
            }
        }

        static void CustomExceptions()
        {
            int age = 15;

            if (age < 18)
            {
                throw new AgeTooSmallException("Age must be 18 or older.");
            }
        }
    }
}

// Custom Exceptions 

public class AgeTooSmallException : Exception
{
    public AgeTooSmallException(string message) : base(message) { }
}
