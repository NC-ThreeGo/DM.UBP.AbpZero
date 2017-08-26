using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DM.UBP.CodeBuilder
{
    public static class Utils
    {
        public static string ToPascalCase(this string s)
        {
            var m = Regex.Match(s, "^(?<word>^[a-z]+|[A-Z]+|[A-Z][a-z]+)+$");
            var g = m.Groups["word"];

            // Take each word and convert individually to TitleCase
            // to generate the final output.  Note the use of ToLower
            // before ToTitleCase because all caps is treated as an abbreviation.
            var t = Thread.CurrentThread.CurrentCulture.TextInfo;
            var sb = new StringBuilder();
            foreach (var c in g.Captures.Cast<Capture>())
                sb.Append(t.ToTitleCase(c.Value.ToLower()));
            return sb.ToString();
        }
    }
}
