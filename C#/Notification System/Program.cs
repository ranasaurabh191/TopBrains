
abstract class Notification
{
    public abstract void Send();

    public void LogNotification()
    {
        Console.WriteLine("Notification Logged");
    }
}

interface IRetryable
{
    void Retry(int count);
}

class EmailNotification : Notification, IRetryable
{
    public override void Send()
    {
        Console.WriteLine("Sending Email...");
    }

    public void Retry(int count)
    {
        Console.WriteLine($"Retry Attempt: {count}");
    }
}

class SmsNotification : Notification, IRetryable
{
    public override void Send()
    {
        Console.WriteLine("Sending SMS...");
    }

    public void Retry(int count)
    {
        Console.WriteLine($"Retry Attempt: {count}");
    }
}

class PushNotification : Notification
{
    public override void Send()
    {
        Console.WriteLine("Sending Push Notification...");
    }
}

class Program
{
    static void Main()
    {
        EmailNotification email = new EmailNotification();
        email.Send();
        email.Retry(1);
        email.LogNotification();
    }
}
