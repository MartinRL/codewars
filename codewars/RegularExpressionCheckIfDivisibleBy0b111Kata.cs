namespace codewars;

public class RegularExpressionCheckIfDivisibleBy0b111Solution
{
    public static string MultipleOf7() {
        // Write a *string* which represents a regular expression to detect whether a binary number is divisible by 7
        return "";
    }
}

public class RegularExpressionCheckIfDivisibleBy0b111Tests
{
    private static string rgxStr = RegularExpressionCheckIfDivisibleBy0b111Solution.MultipleOf7();
    
    [Fact]
    public void EdgeCases()
    {
        System.Console.WriteLine("Testing for: empty string");
        Regex.Match("", rgxStr).Success.Should().BeFalse();
        
        System.Console.WriteLine("Testing for: 0");
        Regex.Match("0", rgxStr).Success.Should().BeTrue();
    }
    
    [Fact]
    public void FixedTests1000()
    {
        for (var i=1; i<100; i++) 
        {
            System.Console.WriteLine("Testing for: "+i.ToString());
            Regex.Match(Convert.ToString(i, 2), rgxStr).Success.Should().Be(i%7 == 0);
        }
    }
}
