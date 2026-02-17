using System.Text;

static string ReverseEnglishOnly(string input)
{
    var sb = new StringBuilder();
    string[] words = input.Split(' ');

    foreach (string word in words)
    {
        bool isEnglish = true;

        foreach (char c in word)
            if (c > 127) { isEnglish = false; break; }

        if (isEnglish)
        {
            for (int i = word.Length - 1; i >= 0; i--)
                sb.Append(word[i]);
        }
        else
            sb.Append(word);

        sb.Append(' ');
    }

    return sb.ToString().Trim();
}
