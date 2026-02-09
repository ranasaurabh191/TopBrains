
static class LogExtensions
{
    public static void ToInfoLog(this string message)
    {
        Console.WriteLine($"[INFO] [{DateTime.Now}] {message}");
    }

    public static void ToWarningLog(this string message)
    {
        Console.WriteLine($"[WARNING] [{DateTime.Now}] {message}");
    }

    public static void ToErrorLog(this string message)
    {
        Console.WriteLine($"[ERROR] [{DateTime.Now}] {message}");
    }
}

class Program
{
    static void Main()
    {
        "User logged in".ToInfoLog();
        "Low disk space".ToWarningLog();
        "Payment failed".ToErrorLog();
    }
}
