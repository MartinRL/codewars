namespace codewars;

public static class FindNextHigherNumberWithSameBitsSolution
{
    public static int Find(int number)
    {
        var next = number;
        
        while (next <= int.MaxValue)
        {
            next++;
            
            if (CountOnes(number) == CountOnes(next))
                return next;
        }
        
        throw new Exception("No next higher number with same bits");

        int CountOnes(int num) => Convert.ToString(num, 2).Count(n => n == '1');
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