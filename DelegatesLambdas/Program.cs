namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Currying();
        }


        static void Currying()
        {
            Func<int, Func<int, Func<int, int>>> sum = x => y => z => x + y + z;
            Console.WriteLine("SUM: {0}", sum(1)(2)(3));

            Func<int, Func<int, Func<int, int>>> sum3 = x =>
            {
                Func<int, Func<int, int>> second = y =>
                {
                    Func<int, int> third = z =>
                    {
                        return x + y + z;
                    };
                    return third;
                };
                return second;
            };
            Console.WriteLine("SUM: {0}", sum3(1)(2)(3));
        }
    }
}
