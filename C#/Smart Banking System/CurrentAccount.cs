class CurrentAccount : BankAccount
{
    public decimal OverdraftLimit { get; set; } = 20000;

    public override void Withdraw(decimal amount)
    {
        if (Balance + OverdraftLimit < amount)
            throw new InsufficientBalanceException();

        Balance -= amount;
    }

    public override decimal CalculateInterest() => 0;
}
