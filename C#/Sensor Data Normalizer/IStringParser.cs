public interface IStringParser
{
    bool TryParse(string input, out float value);
}