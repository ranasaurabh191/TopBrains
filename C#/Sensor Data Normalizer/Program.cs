class Program
{
    static void Main()
    {
        string input = " 24.5678, 18.9, null, , 31.0049, error, 29, 17.999, NaN ";

        SensorDataNormalizer normalizer = new SensorDataNormalizer();

        float[]? normalizedData = normalizer.Normalize(input);

        if (normalizedData == null)
        {
            Console.WriteLine("No valid sensor data found.");
        }
        else
        {
            Console.WriteLine("{ " + string.Join(", ", normalizedData.Select(v => v.ToString("F2"))) + " }");
        }
    }
}