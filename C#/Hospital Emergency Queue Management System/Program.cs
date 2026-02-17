using System;

public class HospitalException : Exception
{
    public HospitalException(string message) : base(message) { }
}

public class InvalidSeverityException : HospitalException
{
    public InvalidSeverityException(string message) : base(message) { }
}

public class PatientNotFoundException : HospitalException
{
    public PatientNotFoundException(string message) : base(message) { }
}

public class QueueOverflowException : HospitalException
{
    public QueueOverflowException(string message) : base(message) { }
}
class Program
{
    static void Main()
    {
        EmergencyQueueManager manager = new EmergencyQueueManager();

        try
        {
            manager.AddPatient(new Patient("P101", "Rahul", 1));
            manager.AddPatient(new Patient("P102", "Anita", 2));
            manager.AddPatient(new Patient("P103", "Karan", 1));

            Patient next = manager.GetNextPatient();
            next.Treat();   

            manager.RemovePatient("P102");
        }
        catch (HospitalException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
