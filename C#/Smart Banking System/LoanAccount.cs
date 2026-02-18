class LoanAccount : BankAccount
{
    public override void Deposit(decimal amount)
        => throw new InvalidTransactionException("Cannot deposit to loan");

    public override decimal CalculateInterest() => Balance * 0.10m;
}
