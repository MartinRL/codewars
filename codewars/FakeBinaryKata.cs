namespace codewars;

using static String;

public class FakeBinarySolution
{
    public static string Fake(string s) => Concat(s.Select(c => c / '5'));
}

public class FakeBinaryTests
{
    [Theory]
    [InlineData("45385593107843568", "01011110001100111")]
    [InlineData("509321967506747", "101000111101101")]
    [InlineData("366058562030849490134388085", "011011110000101010000011011")]
    public void VerifyFakeWith(string s, string expectedFake) => FakeBinarySolution.Fake(s).Should().Be(expectedFake);
}
