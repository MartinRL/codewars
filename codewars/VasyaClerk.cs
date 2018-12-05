using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class VasyaClerkKata
    {
        public static string Tickets(int[] peopleInLine)
        {
            var billsOf25s = 0;
            var billsOf50s = 0;

            foreach (var bill in peopleInLine)
            {
                switch (bill)
                {
                    case 25:
                        ++billsOf25s;
                        break;
                    case 50:
                        --billsOf25s;
                        ++billsOf50s;
                        break;
                    case 100:
                        if (billsOf50s > 0)
                        {
                            --billsOf50s;
                            --billsOf25s;
                        }
                        else
                        {
                            billsOf25s -= 3;
                        }
                        break;
                }

                if (billsOf25s < 0)
                    return "NO";
            }

            return "YES";
        }
    }

    public class VasyaClerkTests
    {
        [Theory]
        [InlineData(new[] {25, 25, 50}, "YES")]
        [InlineData(new[] {25, 25, 25, 100}, "YES")]
        [InlineData(new[] {25, 25, 25, 25, 50, 100}, "YES")]
        [InlineData(new[] {25, 25, 25, 25, 25, 25, 100, 100}, "YES")]
        [InlineData(new[] {25, 100}, "NO")]
        [InlineData(new[] {25, 25, 50, 50, 100}, "NO")]
        public void ExecuteTicketsExample(int[] peopleInLine, string canGiveChangeToEveryone)
        {
            VasyaClerkKata.Tickets(peopleInLine).Should().Be(canGiveChangeToEveryone);
        }
    }
}
