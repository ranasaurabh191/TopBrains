using System.Text;

static string AnalyzePassword(string password)
{
    bool upper = false, lower = false, digit = false, special = false, space = false;

    foreach (char c in password)
    {
        if (char.IsUpper(c)) upper = true;
        else if (char.IsLower(c)) lower = true;
        else if (char.IsDigit(c)) digit = true;
        else if (c == ' ') space = true;
        else special = true;
    }

    var sb = new StringBuilder();
    sb.Append("Length: ").Append(password.Length >= 8 ? "OK" : "Missing");
    sb.Append(" | Uppercase: ").Append(upper ? "OK" : "Missing");
    sb.Append(" | Lowercase: ").Append(lower ? "OK" : "Missing");
    sb.Append(" | Digit: ").Append(digit ? "OK" : "Missing");
    sb.Append(" | Special: ").Append(special && !space ? "OK" : "Missing");

    return sb.ToString();
}
