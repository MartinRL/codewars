namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class PlayingOnAChessboardSolution
    {
        public static string Game(long n) => throw new NotImplementedException();
    }
    public class Fraction
    {
        public long Numerator, Denominator;

        // Initialize the fraction from a string A/B.
        public Fraction(string txt)
        {
            var pieces = txt.Split('/');
            Numerator = long.Parse(pieces[0]);
            Denominator = long.Parse(pieces[1]);
        }

        // Initialize the fraction from numerator and denominator.
        public Fraction(long numer, long denom)
        {
            Numerator = numer;
            Denominator = denom;
        }

        // Return a * b.
        public static Fraction operator *(Fraction a, Fraction b)
        {
            // Swap numerators and denominators to simplify.
            Fraction result1 = new Fraction(a.Numerator, b.Denominator);
            Fraction result2 = new Fraction(b.Numerator, a.Denominator);

            return new Fraction(
                result1.Numerator * result2.Numerator,
                result1.Denominator * result2.Denominator);
        }

        // Return -a.
        public static Fraction operator -(Fraction a)
        {
            return new(-a.Numerator, a.Denominator);
        }

        // Return a + b.
        public static Fraction operator +(Fraction a, Fraction b)
        {
            var numer = a.Numerator * b.Denominator + b.Numerator * a.Denominator;

            var denom = a.Denominator * b.Denominator;

            return new Fraction(numer, denom);
        }

        // Return a - b.
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return a + -b;
        }

        // Return a / b.
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return a * new Fraction(b.Denominator, b.Numerator);
        }

        // Convert a to a double.
        public static implicit operator double(Fraction a)
        {
            return (double)a.Numerator / a.Denominator;
        }

        public override string ToString() => $"{Numerator}/{Denominator}";
    }

    public class PlayingOnAChessboardTests
    {
        [Theory]
        [InlineData(0, "[0]")]
        [InlineData(1, "[1, 2]")]
        [InlineData(8, "[32]")]
        public void VerifyGameWith(long n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);

        [Theory]
        [InlineData(1, 2, )]
        [InlineData(1, "[1, 2]")]
        [InlineData(8, "[32]")]
        public void VerifyGameWith(long n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);
    }
}
