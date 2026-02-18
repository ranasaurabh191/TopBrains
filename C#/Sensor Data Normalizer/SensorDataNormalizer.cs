public class SensorDataNormalizer : IStringParser, INumberRounder
{
    
    public bool TryParse(string input, out float value)
    {
        value = 0f;

        if (string.IsNullOrWhiteSpace(input))  return false;

        string cleaned = input.Trim();

        if (cleaned.Equals("null", StringComparison.OrdinalIgnoreCase) ||   cleaned.Equals("NaN", StringComparison.OrdinalIgnoreCase))
            return false;

        return float.TryParse(cleaned, NumberStyles.Float, CultureInfo.InvariantCulture, out value);
    }

    public float Round(float value, int decimals)
    {
        return (float)Math.Round(value, decimals);
    }


    public float[]? Normalize(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) return null;

        List<float> result = new();

        string[] parts = input.Split(',');

        foreach (var part in parts)
        {
            if (TryParse(part, out float number))
            {
                float rounded = Round(number, 2);
                result.Add(rounded);
            }
        }

        return result.Count > 0 ? result.ToArray() : null;
    }
}
