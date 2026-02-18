class SavingsAccount : BankAccount
{
    public const decimal MinBalance = 5000;

    public override void Withdraw(decimal amount)
    {
        if (Balance - amount < MinBalance)
            throw new MinimumBalanceException();

        base.Withdraw(amount);
    }

    public override decimal CalculateInterest() => Balance * 0.04m;
}


