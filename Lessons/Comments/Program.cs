namespace Comments
{
    class Program
    {
        /// XML Comments are used to help provide documentation
        /// They start with triple-slashes and have a special syntax
        /// <summary>
        /// This is the main sample application function.
        /// </summary>
        /// <param name='args'>An array of string arguments from the command line</param>
        /// <returns>
        /// No return value
        /// </returns>
        static void Main(string[] args)
        {
            // Single line comments start with two slashes
            // You can have as many of these as you want
            Console.WriteLine("Hello World!");

            /* Multiple line comments start with a slash and star
            and can continue for several lines
            until a closing star and slash are encountered */
        }
    }
}
