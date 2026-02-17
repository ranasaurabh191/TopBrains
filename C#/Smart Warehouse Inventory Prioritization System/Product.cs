public abstract class Product
{
    private int stock;
    public string SKU { get; }
    public string Name { get; }
    public int Priority { get; }

    protected Product(string sku, string name, int priority, int stock)
    {
        if (priority < 1 || priority > 10) throw new InvalidProductException("Priority must be between 1 and 10");

        SKU = sku;
        Name = name;
        Priority = priority;
        Stock = stock;
    }

    public int Stock
    {
        get => stock;
        protected set
        {
            if (value < 0) throw new InvalidProductException("Stock cannot be negative");

            stock = value;
        }
    }

    public void UpdateStock(int newStock, int threshold)
    {
        Stock = newStock;

        if (Stock < threshold) throw new LowStockException($"Low stock alert for {Name} (SKU: {SKU})");
    }
}
