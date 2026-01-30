#define DEBUG
#define FEATURE_X

using System;

#nullable disable

namespace PreprocessorDirectives
{
    class Program
    {
        static void Main()
        {
            string name = null;


            #region Startup
#line 100
            Console.WriteLine("Application started");
            #endregion

#line default
            Console.WriteLine("Back to normal");

#if DEBUG
#warning DEBUG mode is enabled
            Console.WriteLine("Running in DEBUG mode");
#elif RELEASE
            Console.WriteLine("Running in RELEASE mode");
#else
#error Invalid configuration
#endif

#if FEATURE_X
            Console.WriteLine("Feature X is enabled");
#else
            Console.WriteLine("Feature X is disabled");
#endif

#undef FEATURE_X

#if FEATURE_X
            Console.WriteLine("This will NOT compile");
#else
            Console.WriteLine("Feature X was undefined");
#endif

#pragma warning disable 0168
            int unusedVariable;
#pragma warning restore 0168

            Console.WriteLine("Application finished");
        }
    }
}
