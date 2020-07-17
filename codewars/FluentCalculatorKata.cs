namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using static System.Math;
    using static System.Convert;
    using FluentAssertions;
    using Xunit;

    public class FluentCalculator
    {
        private readonly Stack<char> stack = new Stack<char>();

        public FluentCalculator Zero
        {
            get
            {
                stack.Push('0');

                return this;
            }
        }

        public FluentCalculator One
        {
            get
            {
                stack.Push('1');

                return this;
            }
        }

        public FluentCalculator Two
        {
            get
            {
                stack.Push('2');

                return this;
            }
        }

        public FluentCalculator Three
        {
            get
            {
                stack.Push('3');

                return this;
            }
        }

        public FluentCalculator Four
        {
            get
            {
                stack.Push('4');

                return this;
            }
        }

        public FluentCalculator Five
        {
            get
            {
                stack.Push('5');

                return this;
            }
        }

        public FluentCalculator Six
        {
            get
            {
                stack.Push('6');

                return this;
            }
        }

        public FluentCalculator Seven
        {
            get
            {
                stack.Push('7');

                return this;
            }
        }

        public FluentCalculator Eight
        {
            get
            {
                stack.Push('8');

                return this;
            }
        }

        public FluentCalculator Nine
        {
            get
            {
                stack.Push('9');

                return this;
            }
        }

        public FluentCalculator Ten
        {
            get
            {
                stack.Push('1');
                stack.Push('0');

                return this;
            }
        }

        public FluentCalculator Plus
        {
            get
            {
                stack.Push('+');

                return this;
            }
        }

        public FluentCalculator Minus
        {
            get
            {
                stack.Push('-');

                return this;
            }
        }

        public FluentCalculator Times
        {
            get
            {
                stack.Push('*');

                return this;
            }
        }

        public FluentCalculator DividedBy
        {
            get
            {
                stack.Push('/');

                return this;
            }
        }

        public double Result() => Round(ToDouble(new DataTable().Compute(string.Concat(stack), string.Empty)), 6);

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
