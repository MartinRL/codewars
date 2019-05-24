using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class RoboScriptNo1Solution
    {
        public static string Highlight(string code)
        {
            return string.Join(string.Empty,code
                .Select(c => c.ToString())
                .Select(s =>
                {
                    if (s == "F")
                        return $"<span style=\"color: pink\">{s}</span>";
                    
                    if (s == "L")
                        return $"<span style=\"color: red\">{s}</span>";

                    if (s == "R")
                        return $"<span style=\"color: green\">{s}</span>";

                    byte r;
                    if (byte.TryParse(s, out r))
                        return $"<span style=\"color: orange\">{s}</span>";

                    return s;
                }).ToArray());
        }
    }

    public class RoboScriptNo1Tests
    {
        [Theory]
        [InlineData("F3RF5LF7", "<span style=\"color: pink\">F</span><span style=\"color: orange\">3</span><span style=\"color: green\">R</span><span style=\"color: pink\">F</span><span style=\"color: orange\">5</span><span style=\"color: red\">L</span><span style=\"color: pink\">F</span><span style=\"color: orange\">7</span>")]
        [InlineData("FFFR345F2LL", "<span style=\"color: pink\">FFF</span><span style=\"color: green\">R</span><span style=\"color: orange\">345</span><span style=\"color: pink\">F</span><span style=\"color: orange\">2</span><span style=\"color: red\">LL</span>")]
        public void VerifyHighlightWith(string code, string expectedHighlightedCode)
        {
            RoboScriptNo1Solution.Highlight(code).Should().Be(expectedHighlightedCode);
        }
    }
}
