namespace codewars;

public static class FindNextHigherNumberWithSameBitsSolution
{
    public static int Find(int number)
    {
        var next = number;
        
        while (next <= int.MaxValue)
        {
            next++;
            
            if (Convert.ToString(number, 2).Count(n => n == '1') == Convert.ToString(next, 2).Count(n => n == '1'))
                return next;
        }
        
        throw new Exception("No next higher number with same bits");
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