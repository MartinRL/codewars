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
    private static String rgxStr = BinaryRegexp.MultipleOf7();
    
    [Fact]
    public void EdgeCases()
    {
        System.Console.WriteLine("Testing for: empty string");
        Assert.AreEqual(Regex.Match("", rgxStr).Success, false);
        System.Console.WriteLine("Testing for: 0");
        Assert.AreEqual(Regex.Match("0", rgxStr).Success, true);
    }
    
    [Fact]
    public void FixedTests1000()
    {
        for(int i=1; i<100; i++) {
            System.Console.WriteLine("Testing for: "+i.ToString());
            Assert.AreEqual(Regex.Match(Convert.ToString(i, 2), rgxStr).Success, i%7 == 0);
        }
    }
}
