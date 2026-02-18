class OrderItem
{
    public Product Product;
    public int Quantity;
    public decimal TotalPrice() => Product.Price * Quantity;
}