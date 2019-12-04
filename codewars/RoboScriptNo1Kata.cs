using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class RoboScriptNo1Solution
    {
        public static string Highlight(string code)
        {
            string CreateHtmlHighlight(string color) { return $"<span style=\"color: {color}\">$1</span>"; }
            
            return Regex.Replace(Regex.Replace(Regex.Replace(Regex.Replace(code, 
                            @"(\d+)", CreateHtmlHighlight("orange")), 
                            @"(F+)", CreateHtmlHighlight("pink")), 
                            @"(L+)", CreateHtmlHighlight("red")), 
                            @"(R+)", CreateHtmlHighlight("green"));
        }
    }

    public class RoboScriptNo1Tests
    {
        [Theory]
        [InlineData("F3RF5LF7", "<span style=\"color: pink\">F</span><span style=\"color: orange\">3</span><span style=\"color: green\">R</span><span style=\"color: pink\">F</span><span style=\"color: orange\">5</span><span style=\"color: red\">L</span><span style=\"color: pink\">F</span><span style=\"color: orange\">7</span>")]
        [InlineData("FFFR345F2LL", "<span style=\"color: pink\">FFF</span><span style=\"color: green\">R</span><span style=\"color: orange\">345</span><span style=\"color: pink\">F</span><span style=\"color: orange\">2</span><span style=\"color: red\">LL</span>")]
        public void VerifyHighlightWith(string code, string expectedHighlightedCode) => RoboScriptNo1Solution.Highlight(code).Should().Be(expectedHighlightedCode);
    }
}
