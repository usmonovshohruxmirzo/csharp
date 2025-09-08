namespace ObjectOrientedProgramming.Concepts
{
    public class PrinciplesOfOOP
    {
        public static void RunPrinciplesOfOOP()
        {

        }
    }
}

public interface ITransaction
{
    void Deposit(double amount);
    void Withdraw(double amount);
    void Transfer(Account toAccount, double amount);
}

public class Account : ITransaction
{
    private static int accountCounter = 1000;

    private double balance;

    public int AccountNumber { get; private set; }
    public string OwnerName { get; private set; }
    public double Balance => balance;

    public Account(string ownerName, double initialBalance)
    {
      this.AccountNumber = ++accountCounter;
      this.OwnerName = ownerName;
      this.balance = initialBalance;
    }

    public void Deposit(double amount) { }
    public void Withdraw(double amount) { }
    public void Transfer(Account toAccount, double amount) { }
}
