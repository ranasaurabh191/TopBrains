using System.Text;

static string NormalizeUrl(string url)
{
    var sb = new StringBuilder();
    url = url.Trim();

    int idx = url.IndexOf("://");
    sb.Append(url.Substring(0, idx).ToLower())
      .Append("://");

    bool slash = false;

    for (int i = idx + 3; i < url.Length; i++)
    {
        if (url[i] == '/')
        {
            if (!slash) sb.Append('/');
            slash = true;
        }
        else
        {
            slash = false;
            if (url[i] == '%' && i + 2 < url.Length && url.Substring(i, 3) == "%20")
            {
                sb.Append(' ');
                i += 2;
            }
            else
                sb.Append(url[i]);
        }
    }

    if (sb[^1] == '/') sb.Length--;

    return sb.ToString();
}

