class Order
{
    public int OrderId;
    public Customer Customer;
    public List<OrderItem> Items = new();
    public DateTime OrderDate = DateTime.Now;
    public string Status = "Placed";
}