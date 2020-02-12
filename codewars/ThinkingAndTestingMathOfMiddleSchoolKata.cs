namespace codewars
{
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class ThinkingAndTestingMathOfMiddleSchoolSolution
    {
        public static int[] TestIt(int[] a, int[] b)
        {
            if (!a.Any(n => n > 0) || !b.Any(n => n > 0))
                return a;

            var pos = a.Zip(b, (an, bn) => new[] {an, bn}).ToList().FindIndex(_ => _.All(n => n > 0));

            var r = new[] {0, 0, 0, 0};
            r[pos] = a.Max() * b.Max() + a.Where(n => n > 0).Min() * b.Where(n => n > 0).Min();

            return r;
        }
    }

    public class ThinkingAndTestingMathOfMiddleSchoolTests
    {
        [Theory]
        [InlineData(new[] {0, 0, 0, 0}, new[] {0, 0, 0, 0}, new[] {0, 0, 0, 0})]
        [InlineData(new[] {22, 88, 0, 0}, new[] {0, 100, 0, 100}, new[] {0, 11000, 0, 0})]
        [InlineData(new[] {0, 0, 96, 49}, new[] {86, 0, 53, 0}, new[] {0, 0, 10853, 0})]
        [InlineData(new[] {0, 0, 83, 88}, new[] {0, 27, 0, 99}, new[] {0, 0, 0, 10953})]
        [InlineData(new[] {82, 31, 65, 39}, new[] {55, 36, 21, 48}, new[] {5161, 4440, 4394, 4212})]
        [InlineData(new[] {26, 81, 39, 46}, new[] {83, 0, 98, 26}, new[] {10096, 2106, 7745, 1196})]
        public void VerifyTestItWith(int[] a, int[] b, int[] expected) => ThinkingAndTestingMathOfMiddleSchoolSolution.TestIt(a, b).Should().BeEquivalentTo(expected);
    }
}
