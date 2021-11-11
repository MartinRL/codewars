namespace codewars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.NetworkInformation;
    using FluentAssertions;
    using Xunit;

    public static class NumberOfPeopleInTheBusSolution
    {
        public static int Number(IEnumerable<int[]> peopleListInOut) => peopleListInOut.Select(_ => _[0] - _[1]).Sum();
    }

    public class NumberOfPeopleInTheBusTests
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[] { new List<int[]> { new[] {10,0}, new[] {3,5}, new[] {5,8} }, 5},
                new object[] { new List<int[]> { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 10 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 10 } }, 17},
                new object[] { new List<int[]> { new[] { 3, 0 }, new[] { 9, 1 }, new[] { 4, 8 }, new[] { 12, 2 }, new[] { 6, 1 }, new[] { 7, 8 } }, 21},
            };

        [Theory]
        [MemberData(nameof(Cases))]
        public void VerifyNumberWith(List<int[]> peopleListInOut, int expectedNumber) => NumberOfPeopleInTheBusSolution.Number(peopleListInOut).Should().Be(expectedNumber);
    }
}
