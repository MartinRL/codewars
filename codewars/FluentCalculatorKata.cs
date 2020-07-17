namespace codewars
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using Xunit;

    public class FluentCalculator
    {
        public FluentCalculator()
        {
            throw new NotImplementedException();
        }
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
            calculator.Zero.Minus.Four.Times.Three.Plus.Two.DividedBy.Eight.Times.One.DividedBy.Nine.Should().BeApproximately(-11.972, 0.01);
        }

        [Fact]
        public static void StaticCombinationCalls() => (10 * new FluentCalculator().Six.Plus.Four.Times.Three.Minus.Two.DividedBy.Eight.Times.One.Minus.Five.Times.Zero).Should().Be(177.5);
    }
}
