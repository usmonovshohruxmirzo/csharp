namespace NUnitTesting
{
    public class Calculator : ICalculator
    {
        public int Add(int a, int b) => a + b;

        public int Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return a / b;
        }

        public async Task<int> AddAsync(int a, int b)
        {
            await Task.Delay(10);
            return a + b;
        }
    }
}
