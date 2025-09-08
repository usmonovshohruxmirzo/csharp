namespace ObjectOrientedProgramming.Concepts
{
    public class PrinciplesOfOOP
    {
        public static void RunPrinciplesOfOOP()
        {
            Bank bank = new Bank();

            SavingsAccount sa1 = new SavingsAccount("Alice", 10000, 5);
            CurrentAccount ca1 = new CurrentAccount("Bob", 5000);

            bank.AddAccount(sa1);
            bank.AddAccount(ca1);

            Space();

            sa1.Deposit(2000);
            sa1.Withdraw(500);
            sa1.AddInterest();

            Space();

            ca1.Withdraw(7000);
            ca1.Transfer(sa1, 2000);

            Space();

            Employee emp = new Employee("Charlie");
            emp.ViewAccount(sa1);

            Space();

            bank.ShowAllAccounts();
        }

        public static void Space()
        {
          for (int i = 0; i < 2; i++)
          {
            Console.WriteLine("");
          }
        }
    }
}

// INFO: Bank Account =============================

public interface ITransaction
{
    void Deposit(double amount);
    void Withdraw(double amount);
    void Transfer(Account toAccount, double amount);
}

public abstract class Account : ITransaction
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

    protected void AddBalance(double amount) => balance += amount;
    protected void ReduceBalance(double amount) => balance -= amount;
    public abstract void Withdraw(double amount);

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            AddBalance(amount);
            Console.WriteLine($"{OwnerName} deposited {amount}. New balance: {Balance}");
        }
        else
        {
            Console.WriteLine("Deposit amount must be positive!");
        }
    }

    public void Transfer(Account toAccount, double amount)
    {
        if (Balance >= amount)
        {
            ReduceBalance(amount);
            toAccount.Deposit(amount);
            Console.WriteLine($"{OwnerName} transferred {amount} to {toAccount.OwnerName}");
        }
        else
        {
            Console.WriteLine("Insufficient balance for transfer!");
        }
    }

    public void ShowAccountDetails()
    {
        Console.WriteLine($"Account Number: {AccountNumber}, Owner: {OwnerName}, Balance: {Balance}");
    }
}

public class SavingsAccount : Account
{
    public double InterestRate { get; protected set; }

    public SavingsAccount(string owner, double initialBalance, double interestRate)
         : base(owner, initialBalance)
    {
        InterestRate = interestRate;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Console.WriteLine($"Withdrawing {amount} from SavingsAccount of {OwnerName}");
            typeof(Account)
                .GetMethod("ReduceBalance", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(this, new object[] { amount });
        }
        else
        {
            Console.WriteLine("Insufficient balance in SavingsAccount!");
        }
    }

    public void AddInterest()
    {
        double interest = Balance * InterestRate / 100;
        Deposit(interest);
        Console.WriteLine($"{OwnerName} received interest: {interest}");
    }
}

public class CurrentAccount : Account
{
    public double OverdraftLimit { get; private set; }

    public CurrentAccount(string owner, double initialBalance)
        : this(owner, initialBalance, 5000)
    {
    }

    public CurrentAccount(string owner, double initialBalance, double overdraftLimit)
        : base(owner, initialBalance)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= Balance + OverdraftLimit)
        {
            Console.WriteLine($"Withdrawing {amount} from CurrentAccount of {OwnerName}");
            typeof(Account)
                .GetMethod("ReduceBalance", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                ?.Invoke(this, new object[] { amount });
        }
        else
        {
            Console.WriteLine("Exceeded overdraft limit!");
        }
    }
}

public class Employee
{
    public string Name { get; private set; }
    public int EmployeeId { get; private set; }

    private static int idCounter = 100;

    public Employee(string name)
    {
        EmployeeId = ++idCounter;
        Name = name;
    }

    public void ViewAccount(Account account)
    {
        Console.WriteLine($"Employee {Name} is viewing account details:");
        account.ShowAccountDetails();
    }
}

public class Bank
{
    private List<Account> accounts = new List<Account>();

    public void AddAccount(Account account)
    {
        accounts.Add(account);
        Console.WriteLine($"Account {account.AccountNumber} added for {account.OwnerName}");
    }

    public void ShowAllAccounts()
    {
        Console.WriteLine("All Bank Accounts:");
        foreach (var acc in accounts)
        {
            acc.ShowAccountDetails();
        }
    }
}
