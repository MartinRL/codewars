namespace codewars;

using System.Data;
using static Math;
using static Convert;

public static class Extensions
{
    public static IEnumerable<string> ToChunks(this IEnumerable<char> @this, int size)
    {
        for (var i = 0; i < @this.Count(); i += size)
            yield return string.Concat(@this.Skip(i).Take(size));
    }

    public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
    {
        foreach (var element in @this)
        {
            action(element);
        }
    }

    public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> @this, int k) => k == 0
        ? new[] {new T[0]}
        : @this.SelectMany((e, i) => @this
            .Skip(i + 1)
            .Combinations(k - 1)
            .Select(c => new[] {e}.Concat(c)));

    public static int[] ToDigits(this int @this) => [.. @this.ToString().Select(_ => (int) char.GetNumericValue(_))];

    public static int ToNumber(this IEnumerable<int> @this) => int.Parse(string.Join(string.Empty, @this));

    public static string Repeating(this string @this)
    {
        var repeatingLength = 0;

        for (var i = 0; i < @this.Length; i++)
        {
            if (@this == string.Join(string.Empty, Enumerable.Repeat(@this.Substring(0, i + 1), @this.Length / (i + 1))) + @this.Substring(0, @this.Length % (i + 1)))
            {
                repeatingLength = i + 1;
                break;
            }
        }

        return @this.Substring(0, repeatingLength);
    }

    public static IEnumerable<int> Divisors(this int @this) => Enumerable.Range(1, @this / 2).Where(_ => @this % _ == 0).Concat(new[] {@this});

    public static double Square(this int @this) => Math.Pow(@this, 2);

    public static bool IsInteger(this double @this) => @this % 1 == 0;

    public static string AsString(this IEnumerable<char> @this) => new([.. @this]);

    public static string ToBinaryString(this int @this) => Convert.ToString(@this, 2);

    public static int CountTrue(this IEnumerable<bool> @this) => @this.Count(_ => _);

    public static string ReplaceLastOccurrence(this string @this, string oldValue, string newValue)
    {
        var pos = @this.LastIndexOf(oldValue);

        return pos == -1 ? @this : @this.Remove(pos, oldValue.Length).Insert(pos, newValue);
    }

    public static string Spaces(this int @this) => new string(' ', @this);

    public static IEnumerable<T> ToIEnumerable<T>(this T @this) => new[] { @this };
    public static string ReverseString(this string @this) => new([.. @this.Reverse()]);

    public static char ToggleCase(this char @this) => char.IsLower(@this) ? char.ToUpper(@this) : char.ToLower(@this);

    public static T Second<T>(this IEnumerable<T> @this) => @this.ElementAt(1);

    public static double Compute(this string @this) => Round(ToDouble(new DataTable().Compute(@this, string.Empty)), 6);
}

public class ExtensionsTests
{
    [Theory]
    [InlineData("1939193919", "1939")]
    [InlineData("1939193919391939", "1939")]
    [InlineData("445547544554754455475445", "4455475")]
    public void VerifyRepeatingWith(string str, string repeats) => str.Repeating().Should().Be(repeats);

    [Fact]
    public void VerifyDivisors() => 42.Divisors().Should().BeEquivalentTo(new[] {1, 2, 3, 6, 7, 14, 21, 42});
}
