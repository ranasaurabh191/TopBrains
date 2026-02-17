using System.Text;

static string GenerateAuditTrail(string[] actions, string[] times)
{
    var sb = new StringBuilder();

    for (int i = 0; i < actions.Length; i++)
    {
        sb.Append("[")
          .Append(actions[i])
          .Append(" @ ")
          .Append(times[i])
          .Append("]");

        if (i < actions.Length - 1)
            sb.Append(" -> ");
    }

    return sb.ToString();
}
