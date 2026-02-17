using System.Text;

static string CompressChat(string input)
{
    var sb = new StringBuilder();
    int count = 1;

    for (int i = 1; i <= input.Length; i++)
    {
        if (i < input.Length && input[i] == input[i - 1])
            count++;
        else
        {
            sb.Append(input[i - 1]);
            if (count > 1) sb.Append(count);
            count = 1;
        }
    }

    return sb.ToString();
}
