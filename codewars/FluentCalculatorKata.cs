namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using static System.Math;
    using static System.Convert;
    using FluentAssertions;
    using Xunit;

    public class FluentCalculator
    {
        private readonly Queue<char> queue = new Queue<char>();

        public FluentCalculator Zero
        {
            get
            {
                queue.Enqueue('0');

                return this;
            }
        }

        public FluentCalculator One
        {
            get
            {
                queue.Enqueue('1');

                return this;
            }
        }

        public FluentCalculator Two
        {
            get
            {
                queue.Enqueue('2');

                return this;
            }
        }

        public FluentCalculator Three
        {
            get
            {
                queue.Enqueue('3');

                return this;
            }
        }

        public FluentCalculator Four
        {
            get
            {
                queue.Enqueue('4');

                return this;
            }
        }

        public FluentCalculator Five
        {
            get
            {
                queue.Enqueue('5');

                return this;
            }
        }

        public FluentCalculator Six
        {
            get
            {
                queue.Enqueue('6');

                return this;
            }
        }

        public FluentCalculator Seven
        {
            get
            {
                queue.Enqueue('7');

                return this;
            }
        }

        public FluentCalculator Eight
        {
            get
            {
                queue.Enqueue('8');

                return this;
            }
        }

        public FluentCalculator Nine
        {
            get
            {
                queue.Enqueue('9');

                return this;
            }
        }

        public FluentCalculator Ten
        {
            get
            {
                queue.Enqueue('1');
                queue.Enqueue('0');

                return this;
            }
        }

        public FluentCalculator Plus
        {
            get
            {
                queue.Enqueue('+');

                return this;
            }
        }

        public FluentCalculator Minus
        {
            get
            {
                queue.Enqueue('-');

                return this;
            }
        }

        public FluentCalculator Times
        {
            get
            {
                queue.Enqueue('*');

                return this;
            }
        }

        public FluentCalculator DividedBy
        {
            get
            {
                queue.Enqueue('/');

                return this;
            }
        }

        public double Result()
        {
            var expression = string.Concat(queue);

            var result = Round(ToDouble(new DataTable().Compute(expression, string.Empty)), 6);;

            queue.Clear();

            return result;
        }

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
