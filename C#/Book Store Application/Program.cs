using System;

class Program
{
    static void Main()
    {
       
        string[] input = Console.ReadLine().Split(' ');
        
        Book book = new Book
        {
            Id = input[0],
            Title = input[1],
            Price = int.Parse(input[2]),
            Stock = int.Parse(input[3])
        };

        BookUtility utility = new BookUtility(book);

        while (true)
        {
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    utility.GetBookDetails();
                    break;

                case 2:
                    int newPrice = int.Parse(Console.ReadLine());
                    utility.UpdateBookPrice(newPrice);
                    break;

                case 3:
                    int newStock = int.Parse(Console.ReadLine());
                    utility.UpdateBookStock(newStock);
                    break;

                case 4:
                    Console.WriteLine("Thank You");
                    return;
            }
        }
    }
}
