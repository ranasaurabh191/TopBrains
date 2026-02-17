using System.Text;
using System.Collections.Generic;

static string ObfuscateCode(string code)
{
    var keywords = new HashSet<string> { "int", "float", "double", "return" };
    var map = new Dictionary<string, string>();
    int counter = 1;

    var sb = new StringBuilder();
    var word = new StringBuilder();

    foreach (char c in code + " ")
    {
        if (char.IsLetter(c))
            word.Append(c);
        else
        {
            if (word.Length > 0)
            {
                string w = word.ToString();

                if (!keywords.Contains(w))
                {
                    if (!map.ContainsKey(w))
                        map[w] = "var" + counter++;

                    sb.Append(map[w]);
                }
                else
                    sb.Append(w);

                word.Clear();
            }
            sb.Append(c);
        }
    }

    return sb.ToString().Trim();
}
