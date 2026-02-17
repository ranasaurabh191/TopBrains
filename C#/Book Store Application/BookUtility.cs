public class BookUtility
{
    private Book book;

    public BookUtility(Book book)
    {
        this.book = book;
    }

    public void GetBookDetails()
    {
        Console.WriteLine($"Details: {book.Id} {book.Title} {book.Price} {book.Stock}");
    }

    public void UpdateBookPrice(int newPrice)
    {
        book.Price = newPrice;
        Console.WriteLine($"Updated Price: {newPrice}");
    }

    public void UpdateBookStock(int newStock)
    {
        book.Stock = newStock;
        Console.WriteLine($"Updated Stock: {newStock}");
    }
}
