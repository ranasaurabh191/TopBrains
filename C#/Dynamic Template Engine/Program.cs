using System.Text;
using System.Collections.Generic;

static string ProcessTemplate(string template, Dictionary<string, string> data)
{
    var sb = new StringBuilder();

    for (int i = 0; i < template.Length; i++)
    {
        if (template[i] == '{')
        {
            int end = template.IndexOf('}', i);
            string key = template.Substring(i + 1, end - i - 1);

            sb.Append(data.ContainsKey(key) ? data[key] : "N/A");
            i = end;
        }
        else
        {
            sb.Append(template[i]);
        }
    }

    return sb.ToString();
}
