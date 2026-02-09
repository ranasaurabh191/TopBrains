
class PaymentCalculator
{
    static void Main()
    {
        decimal baseAmount = 6000;
        decimal tax, discount, finalAmount;

        CalculateBill(ref baseAmount, out tax, out discount, out finalAmount);

        Console.WriteLine($"Base Amount (After Discount): {baseAmount}");
        Console.WriteLine($"Tax: {tax}");
        Console.WriteLine($"Discount: {discount}");
        Console.WriteLine($"Final Amount: {finalAmount}");
    }

    static void CalculateBill(ref decimal baseAmount, out decimal tax, out decimal discount, out decimal finalAmount)
    {
        discount = baseAmount > 5000 ? baseAmount * 0.10m : 0;
        baseAmount -= discount;

        tax = baseAmount * 0.18m;
        finalAmount = baseAmount + tax;
    }
}
