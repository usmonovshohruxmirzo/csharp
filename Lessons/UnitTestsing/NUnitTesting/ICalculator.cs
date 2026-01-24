namespace NUnitTesting
{
    public interface ICalculator
    {
        int Add(int a, int b);
        int Divide(int a, int b);
        Task<int> AddAsync(int a, int b);
    }
}
