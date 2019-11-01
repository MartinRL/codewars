using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class TwoBeggarsAndGoldSolution
    {
        public static (int a, int b) DistributionOf(IEnumerable<int> golds)
        {
            var _a = 0;
            var _b = 0;
            var goldEnumerable = golds;

            void AssignBiggestPileTo(ref int beggar)
            {
                if (goldEnumerable.Last() > goldEnumerable.First())
                {
                    beggar += goldEnumerable.Last();
                    goldEnumerable = goldEnumerable.Take(goldEnumerable.Count() - 1);
                    return;
                }
                
                beggar += goldEnumerable.First();
                goldEnumerable = goldEnumerable.Skip(1);
            }

            for (var i = 0; i < golds.Count(); i++)
            {
                switch (i % 2)
                {
                    case 0:
                        AssignBiggestPileTo(ref _a);
                        break;
                    default: 
                        AssignBiggestPileTo(ref _b);
                        break;
                }
            }

            return (_a, _b);
        }
    }

    public class TwoBeggarsAndGoldTests
    {
        [Theory]
        [InlineData(new [] {4, 2, 9, 5, 2, 7}, 14, 15)]
        [InlineData(new [] {4, 7, 2, 9, 5, 2}, 11, 18)]
        [InlineData(new [] {10, 1000, 2, 1}, 12, 1001)]
        public void VerifyDistributionOfWith(int[] golds, int expectedA, int expectedB) => TwoBeggarsAndGoldSolution.DistributionOf(golds).Should().Be((expectedA, expectedB));
    }
}
