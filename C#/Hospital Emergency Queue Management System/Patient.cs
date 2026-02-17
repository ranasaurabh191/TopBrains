public class Patient : Person
{
    private int severity;

    public int Severity
    {
        get => severity;
        private set
        {
            if (value < 1 || value > 5) throw new InvalidSeverityException("Severity must be between 1 and 5");
            severity = value;
        }
    }

    public Patient(string id, string name, int severity) : base(id, name)
    {
        Severity = severity;
    }

    public override void Treat()
    {
        Console.WriteLine($"Treating Patient: {Name} | Severity: {Severity}");
    }
}
