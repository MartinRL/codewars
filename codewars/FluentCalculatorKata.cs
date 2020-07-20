namespace codewars
{
    using System;
    using System.Data;
    using static System.Math;
    using static System.Convert;
    using FluentAssertions;
    using Xunit;

    public class FluentCalculator
    {
        private readonly Func<double, double, double> plus = (operand1, operand2) => operand1 + operand2;
        private readonly Func<double, double, double> minus = (operand1, operand2) => operand1 - operand2;
        private readonly Func<double, double, double> times = (operand1, operand2) => operand1 * operand2;
        private readonly Func<double, double, double> dividedBy = (operand1, operand2) => operand1 / operand2;
        private Func<double, double, double> expression;
        private double number = 0;

        public FluentCalculator() => expression = plus;

        public FluentCalculator Zero
        {
            get
            {
                number = expression(number, 0);

                return this;
            }
        }

        public FluentCalculator One
        {
            get
            {
                number = expression(number, 1);

                return this;
            }
        }

        public FluentCalculator Two
        {
            get
            {
                number = expression(number, 2);

                return this;
            }
        }

        public FluentCalculator Three
        {
            get
            {
                number = expression(number, 3);

                return this;
            }
        }

        public FluentCalculator Four
        {
            get
            {
                number = expression(number, 4);

                return this;
            }
        }

        public FluentCalculator Five
        {
            get
            {
                number = expression(number, 5);

                return this;
            }
        }

        public FluentCalculator Six
        {
            get
            {
                number = expression(number, 6);

                return this;
            }
        }

        public FluentCalculator Seven
        {
            get
            {
                number = expression(number, 7);

                return this;
            }
        }

        public FluentCalculator Eight
        {
            get
            {
                number = expression(number, 8);

                return this;
            }
        }

        public FluentCalculator Nine
        {
            get
            {
                number = expression(number, 9);

                return this;
            }
        }

        public FluentCalculator Ten
        {
            get
            {
                number = expression(number, 10);

                return this;
            }
        }

        public FluentCalculator Plus
        {
            get
            {
                expression = plus;

                return this;
            }
        }

        public FluentCalculator Minus
        {
            get
            {
                expression = minus;

                return this;
            }
        }

        public FluentCalculator Times
        {
            get
            {
                expression = times;

                return this;
            }
        }

        public FluentCalculator DividedBy
        {
            get
            {
                expression = dividedBy;

                return this;
            }
        }

        public double Result() => number;

        public static implicit operator double(FluentCalculator fluentCalculator) => fluentCalculator.Result();
    }

    public class FluentCalculatorTests
    {
        [Fact]
        public static void BasicAddition() => new FluentCalculator().One.Plus.Two.Result().Should().Be(3);

        [Fact]
        public static void MultipleInstances() => ((double)new FluentCalculator().Five.Plus.Five).Should().NotBe((double)new FluentCalculator().Seven.Times.Three);

        [Fact]
        public static void MultipleCalls()
        {
            var calculator = new FluentCalculator();

            (calculator.One.Plus.One.Result() + calculator.One.Plus.One.Result()).Should().Be(4);
        }

        [Fact]
        public static void OperatorOrdering() => new FluentCalculator().Two.Plus.Eight.DividedBy.Five.Result().Should().Be(2);

        [Fact]
        public static void Bedmas()
        {
            var calculator = new FluentCalculator();

            ((double)calculator.Six.Times.Six.Plus.Eight.DividedBy.Two.Times.Two.Plus.Ten.Times.Four.DividedBy.Two.Minus.Six).Should().Be(58);
            ((double)calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine).Should().BeApproximately(-11.972, 0.01);
        }

        [Fact]
        public static void StaticCombinationCalls() => (10 * new FluentCalculator().Six.Plus.Four.Times.Three.Minus.Two.DividedBy.Eight.Times.One.Minus.Five.Times.Zero).Should().Be(177.5);
    }
}
