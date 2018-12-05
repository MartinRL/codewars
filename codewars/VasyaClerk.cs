using System;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public static class VasyaClerkKata
    {
        public static string Tickets(int[] peopleInLine)
        { 
            throw new NotImplementedException();
        }
    }

    public class VasyaClerkTests
    {
        [Theory]
        [InlineData(new[] {25, 25, 50}, "YES")]
        [InlineData(new[] {25, 100}, "NO")]
        [InlineData(new[] {25, 25, 50, 50, 100}, "NO")]
        public void ExecuteTicketsExample(int[] peopleInLine, string canGiveChangeToEveryone)
        {
            VasyaClerkKata.Tickets(peopleInLine).Should().Be(canGiveChangeToEveryone);
        }
    }
}
