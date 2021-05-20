namespace codewars
{
    using System;
    using System.Numerics;
    using FluentAssertions;
    using Xunit;

    public class PlayingOnAChessboardSolution
    {
        public static string Game(BigInteger n)
        {
            if (n == 0)
                return "[0]";

            return $"[{n * n}, 2]";
        }
    }

    public struct Fraction : IEquatable<Fraction>
    {
        BigInteger numerator;

        public BigInteger Numerator
        {
            get => numerator;
            private set => numerator = value;
        }

        BigInteger denominator;

        public BigInteger Denominator
        {
            get => denominator == 0 ? 1 : denominator;
            private set
            {
                if (value == 0)
                    throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");

                denominator = value;
            }
        }

        public Fraction(BigInteger value)
        {
            numerator = value;
            denominator = 1;
            Reduce();
        }

        public Fraction(BigInteger numerator, BigInteger denominator)
        {
            if (denominator == 0)
                throw new InvalidOperationException("Denominator cannot be assigned a 0 Value.");

            this.numerator = numerator;
            this.denominator = denominator;
            Reduce();
        }


        private void Reduce()
        {
            try
            {
                if (Numerator == 0)
                {
                    Denominator = 1;
                    return;
                }

                var iGCD = GCD(Numerator, Denominator);
                Numerator /= iGCD;
                Denominator /= iGCD;

                if (Denominator >= 0)
                    return;

                Numerator *= -1;
                Denominator *= -1;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("Cannot reduce Fraction: " + e.Message);
            }
        }

        public bool Equals(Fraction other) => Numerator == other.Numerator && Denominator == other.Denominator;

        public override bool Equals(object obj) => obj is Fraction && Equals((Fraction) obj);

        public override int GetHashCode() => Convert.ToInt32((Numerator ^ Denominator) & 0xFFFFFFFF);

        public override string ToString()
        {
            if (this.Denominator == 1)
                return this.Numerator.ToString();

            var sb = new System.Text.StringBuilder();
            sb.Append(this.Numerator);
            sb.Append('/');
            sb.Append(this.Denominator);

            return sb.ToString();
        }

        public static Fraction Parse(string strValue)
        {
            var i = strValue.IndexOf('/');
            if (i == -1)
                return DecimalToFraction(Convert.ToDecimal(strValue));

            var iNumerator = Convert.ToInt64(strValue.Substring(0, i));
            var iDenominator = Convert.ToInt64(strValue.Substring(i + 1));

            return new Fraction(iNumerator, iDenominator);
        }

        public static bool TryParse(string strValue, out Fraction fraction)
        {
            if (!string.IsNullOrWhiteSpace(strValue))
            {
                try
                {
                    var i = strValue.IndexOf('/');
                    if (i == -1)
                    {
                        if (decimal.TryParse(strValue, out var dValue))
                        {
                            fraction = DecimalToFraction(dValue);

                            return true;
                        }
                    }
                    else
                    {
                        BigInteger iNumerator, iDenominator;
                        if (BigInteger.TryParse(strValue.Substring(0, i), out iNumerator) && BigInteger.TryParse(strValue.Substring(i + 1), out iDenominator))
                        {
                            fraction = new Fraction(iNumerator, iDenominator);

                            return true;
                        }
                    }
                }
                catch
                {
                }
            }

            fraction = new Fraction();

            return false;
        }

        private static Fraction DoubleToFraction(double dValue)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            try
            {
                checked
                {
                    Fraction frac;
                    if (dValue % 1 == 0) // if whole number
                    {
                        frac = new Fraction((BigInteger) dValue);
                    }
                    else
                    {
                        var dTemp = dValue;
                        BigInteger iMultiple = 1;
                        var strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0) // if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }

                        var i = 0;
                        while (strTemp[i] != separator)
                            i++;
                        var iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }

                        frac = new Fraction((int) Math.Round(dTemp), iMultiple);
                    }

                    return frac;
                }
            }
            catch (OverflowException e)
            {
                throw new InvalidCastException("Conversion to Fraction in no possible due to overflow.", e);
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Conversion to Fraction in not possible.", e);
            }
        }

        private static Fraction DecimalToFraction(decimal dValue)
        {
            var separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];

            try
            {
                checked
                {
                    Fraction frac;
                    if (dValue % 1 == 0) // if whole number
                    {
                        frac = new Fraction((BigInteger) dValue);
                    }
                    else
                    {
                        var dTemp = dValue;
                        BigInteger iMultiple = 1;
                        var strTemp = dValue.ToString();
                        while (strTemp.IndexOf("E") > 0) // if in the form like 12E-9
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            strTemp = dTemp.ToString();
                        }

                        var i = 0;
                        while (strTemp[i] != separator)
                            i++;
                        var iDigitsAfterDecimal = strTemp.Length - i - 1;
                        while (iDigitsAfterDecimal > 0)
                        {
                            dTemp *= 10;
                            iMultiple *= 10;
                            iDigitsAfterDecimal--;
                        }

                        frac = new Fraction((int) Math.Round(dTemp), iMultiple);
                    }

                    return frac;
                }
            }
            catch (OverflowException e)
            {
                throw new InvalidCastException("Conversion to Fraction in no possible due to overflow.", e);
            }
            catch (Exception e)
            {
                throw new InvalidCastException("Conversion to Fraction in not possible.", e);
            }
        }

        private static Fraction Inverse(Fraction frac1)
        {
            if (frac1.Numerator == 0)
                throw new InvalidOperationException("Operation not possible (Denominator cannot be assigned a ZERO Value)");

            var iNumerator = frac1.Denominator;
            var iDenominator = frac1.Numerator;

            return new Fraction(iNumerator, iDenominator);
        }

        private static Fraction Negate(Fraction frac1)
        {
            var iNumerator = -frac1.Numerator;
            var iDenominator = frac1.Denominator;

            return new Fraction(iNumerator, iDenominator);
        }

        private static Fraction Add(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    var iNumerator = frac1.Numerator * frac2.Denominator + frac2.Numerator * frac1.Denominator;
                    var iDenominator = frac1.Denominator * frac2.Denominator;

                    return new Fraction(iNumerator, iDenominator);
                }
            }
            catch (OverflowException e)
            {
                throw new OverflowException("Overflow occurred while performing arithemetic operation on Fraction.", e);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while performing arithemetic operation on Fraction.", e);
            }
        }

        private static Fraction Multiply(Fraction frac1, Fraction frac2)
        {
            try
            {
                checked
                {
                    var iNumerator = frac1.Numerator * frac2.Numerator;
                    var iDenominator = frac1.Denominator * frac2.Denominator;

                    return new Fraction(iNumerator, iDenominator);
                }
            }
            catch (OverflowException e)
            {
                throw new OverflowException("Overflow occurred while performing arithemetic operation on Fraction.", e);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while performing arithemetic operation on Fraction.", e);
            }
        }

        private static BigInteger GCD(BigInteger iNo1, BigInteger iNo2)
        {
            if (iNo1 < 0) iNo1 = -iNo1;
            if (iNo2 < 0) iNo2 = -iNo2;

            do
            {
                if (iNo1 < iNo2)
                {
                    var tmp = iNo1;
                    iNo1 = iNo2;
                    iNo2 = tmp;
                }

                iNo1 = iNo1 % iNo2;
            } while (iNo1 != 0);

            return iNo2;
        }

        public static Fraction operator -(Fraction frac1) => (Negate(frac1));

        public static Fraction operator +(Fraction frac1, Fraction frac2) => (Add(frac1, frac2));

        public static Fraction operator -(Fraction frac1, Fraction frac2) => (Add(frac1, -frac2));

        public static Fraction operator *(Fraction frac1, Fraction frac2) => (Multiply(frac1, frac2));

        public static Fraction operator /(Fraction frac1, Fraction frac2) => (Multiply(frac1, Inverse(frac2)));

        public static bool operator ==(Fraction frac1, Fraction frac2) => frac1.Equals(frac2);

        public static bool operator !=(Fraction frac1, Fraction frac2) => (!frac1.Equals(frac2));

        public static bool operator <(Fraction frac1, Fraction frac2) => frac1.Numerator * frac2.Denominator < frac2.Numerator * frac1.Denominator;

        public static bool operator >(Fraction frac1, Fraction frac2) => frac1.Numerator * frac2.Denominator > frac2.Numerator * frac1.Denominator;

        public static bool operator <=(Fraction frac1, Fraction frac2) => frac1.Numerator * frac2.Denominator <= frac2.Numerator * frac1.Denominator;

        public static bool operator >=(Fraction frac1, Fraction frac2) => frac1.Numerator * frac2.Denominator >= frac2.Numerator * frac1.Denominator;

        public static implicit operator Fraction(BigInteger value) => new Fraction(value);

        public static implicit operator Fraction(double value) => DoubleToFraction(value);

        public static implicit operator Fraction(decimal value) => DecimalToFraction(value);

        public static explicit operator double(Fraction frac) => (double) frac.Numerator / (double) frac.Denominator;

        public static explicit operator decimal(Fraction frac) => (decimal) frac.Numerator / (decimal) frac.Denominator;
    }

    public class PlayingOnAChessboardTests
    {
        [Theory]
        [InlineData(0, "[0]")]
        [InlineData(1, "[1, 2]")]
        [InlineData(2, "[2]")]
        [InlineData(3, "[9, 2]")]
        [InlineData(4, "[8]")]
        [InlineData(5, "[25, 2]")]
        [InlineData(6, "[18]")]
        [InlineData(7, "[49, 2]")]
        [InlineData(8, "[32]")]
        //[InlineData(10000, "dummy")]
        public void VerifyGameWith(BigInteger n, string expectedGameOutcome) => PlayingOnAChessboardSolution.Game(n).Should().Be(expectedGameOutcome);
    }
}
