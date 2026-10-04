using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder sb = new StringBuilder();
        bool upperNext = false;

        foreach (char c in identifier)
        {
            if (c == ' ')
            {
                sb.Append('_');
                upperNext = false;
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
                upperNext = false;
            }
            else if (c == '-')
            {
                upperNext = true;
            }
            else if (!char.IsLetter(c))
            {
                // omit anything that is not a letter
            }
            else if (c >= 'α' && c <= 'ω')
            {
                // omit Greek lower case letters
            }
            else
            {
                if (upperNext)
                {
                    sb.Append(char.ToUpper(c));
                    upperNext = false;
                }
                else
                {
                    sb.Append(c);
                }
            }
        }

        return sb.ToString();
    }
}