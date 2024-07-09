namespace codewars;

public class DigitalCypherVol2Solution
{
    public static string Decode(int[] code, int key)
    {
        var keyAsDigits = key.ToDigits();

        return new string([.. code.Select((d, i) => (char)(d + ('a' - 1) - keyAsDigits[i % keyAsDigits.Length]))]);
    }
}

public class DigitalCypherVol2Tests
{
    [Theory]
    [InlineData(new[] {20, 12, 18, 30, 21}, 1939, "scout")]
    [InlineData(new[] {14, 10, 22, 29, 6, 27, 19, 18, 6, 12, 8}, 1939, "masterpiece")]
    public void VerifyDecodeWith(int[] code, int key, string expected) => DigitalCypherVol2Solution.Decode(code, key).Should().Be(expected);
}
