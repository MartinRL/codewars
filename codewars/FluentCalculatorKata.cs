namespace codewars
{
    using System;
    using FluentAssertions;
    using Xunit;

    public class FluentCalculator
    {
        private string expression = string.Empty;

        public FluentCalculator Zero { get { expression += "0"; return this; } }

        public FluentCalculator One { get { expression += "1"; return this; } }

        public FluentCalculator Two { get { expression += "2"; return this; } }

        public FluentCalculator Three { get { expression += "3"; return this; } }

        public FluentCalculator Four { get { expression += "4"; return this; } }

        public FluentCalculator Five { get { expression += "5"; return this; } }

        public FluentCalculator Six { get { expression += "6"; return this; } }

        public FluentCalculator Seven { get { expression += "7"; return this; } }

        public FluentCalculator Eight { get { expression += "8"; return this; } }

        public FluentCalculator Nine { get { expression += "9"; return this; } }

        public FluentCalculator Ten { get { expression += "10"; return this; } }

        public FluentCalculator Plus { get { expression += "+"; return this; } }

        public FluentCalculator Minus { get { expression += "-"; return this; } }

        public FluentCalculator Times { get { expression += "*"; return this; } }

        public FluentCalculator DividedBy { get { expression += "/"; return this; } }

        public double Result()
        {
            var result = expression.Compute();

            expression = string.Empty;

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
