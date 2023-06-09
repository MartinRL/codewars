namespace codewars;

public static class FindNextHigherNumberWithSameBitsSolution
{
    public static int Find(int num)
    {
        int o, n, p, r;
    
        // Find the rightmost set bit of num
        o = num & -num;

        // Flip the rightmost set bit and all bits to the right of it
        n = num + o;

        // Compute the XOR of num and n
        p = num ^ n;

        // Divide p by o, effectively shifting the bits to the right
        p /= o;

        // Right-shift p by 2 positions, equivalent to dividing by 4
        p >>= 2;

        // Combine the rightmost one chunk and the number of ones to move
        r = n | p;

        // Return the next higher number with the same number of set bits
        return r;
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