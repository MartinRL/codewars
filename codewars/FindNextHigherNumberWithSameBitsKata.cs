namespace codewars;

public static class FindNextHigherNumberWithSameBitsSolution
{
    public static int Find(int number)
    {
        throw new NotImplementedException();
    }
}

public class FindNextHigherNumberWithSameBitsTests
{
    [Theory]
    [InlineData(128, 256)]
    [InlineData(1, 2)]
    [InlineData(1022, 1279)]
    [InlineData(127, 191)]
    [InlineData(1253343, 1253359)]
    public void VerifyNextHigherNumberWithSameBitsWith(int number, int expectdNextHigherNumberWithSameBits) 
        => FindNextHigherNumberWithSameBitsSolution.Find(number).Should().Be(expectdNextHigherNumberWithSameBits);
}