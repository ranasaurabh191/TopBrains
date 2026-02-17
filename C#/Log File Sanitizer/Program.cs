using System.Text;

static string SanitizeLog(string input)
{
    var sb = new StringBuilder();
    bool space = false;

    foreach (char c in input.Trim())
    {
        if (c == ' ')
        {
            if (!space)
            {
                sb.Append(' ');
                space = true;
            }
        }
        else
        {
            sb.Append(c);
            space = false;
        }
    }

    string[] tokens = sb.ToString().Split(' ');
    sb.Clear();

    string prev = "";

    foreach (string token in tokens)
    {
        string current = token;

        if (token.Contains("@"))
            current = "***" + token.Substring(token.IndexOf('@'));

        else if (token.Length == 10 && long.TryParse(token, out _))
            current = "******" + token.Substring(6);

        if (current != prev)
        {
            sb.Append(current).Append(' ');
            prev = current;
        }
    }

    return sb.ToString().Trim();
}
