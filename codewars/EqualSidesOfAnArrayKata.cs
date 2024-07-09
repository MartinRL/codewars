namespace codewars;

public class EqualSidesOfAnArraySolution
{
    public static int FindEvenIndex(int[] arr)
    {
        int leftSum = 0, rightSum = arr.Sum();

        for (var i = 0; i < arr.Length; ++i)
        {
            rightSum -= arr[i];

            if (leftSum == rightSum)
                return i;

            leftSum += arr[i];
        }

        return -1;
    }
}

public class EqualSidesOfAnArrayTests
{
    [Theory]
    [InlineData(new[] {1, 2, 3, 4, 3, 2, 1}, 3)]
    [InlineData(new[] {1, 100, 50, -51, 1, 1}, 1)]
    [InlineData(new[] {1, 2, 3, 4, 5, 6}, -1)]
    [InlineData(new[] {20, 10, 30, 10, 10, 15, 35}, 3)]
    public void VerifyFindEvenIndexWith(int[] arr, int expectedIndex) => EqualSidesOfAnArraySolution.FindEvenIndex(arr).Should().Be(expectedIndex);
}
