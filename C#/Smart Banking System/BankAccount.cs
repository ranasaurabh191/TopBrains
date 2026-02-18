public abstract class BankAccount
{
    public int AccountNumber { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; protected set; }

    public List<string> Transactions { get; } = new();

    public void Deposit(decimal amount)
    {
        Balance += amount;
        Transactions.Add($"Deposited {amount}");
    }

    public virtual void Withdraw(decimal amount)
    {
        if (amount > Balance)
            throw new InsufficientBalanceException();

        Balance -= amount;
        Transactions.Add($"Withdrawn {amount}");
    }

    public abstract decimal CalculateInterest();
}
