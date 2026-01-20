
public class Program
{
    //using ref
    public static void SwapUsingRef(ref int a, ref int b)
    {
        a = a + b;
        b = a - b;
        a = a - b;
    }
    // using out
    public static void SwapUsingOut(int a, int b, out int x, out int y)
    {
        a = a + b;
        b = a - b;
        a = a - b;

        x = a;
        y = b;
    }

    public static void Main()
    {
        int num1 = 10, num2 = 20;

        Console.WriteLine("Before swap using ref:");
        Console.WriteLine($"num1 = {num1}, num2 = {num2}");

        SwapUsingRef(ref num1, ref num2);

        Console.WriteLine("After swap using ref:");
        Console.WriteLine($"num1 = {num1}, num2 = {num2}");

        Console.WriteLine();

        int x, y;
        SwapUsingOut(30, 40, out x, out y);

        Console.WriteLine("After swap using out:");
        Console.WriteLine($"x = {x}, y = {y}");
    }
}
