using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class TwoBeggarsAndGoldSolution
    {
        public static (int a, int b) DistributionOf(int[] golds)
        {
            var _a = 0;
            var _b = 0;
            var goldList = golds.ToList();

            for (var i = 0; i < golds.Length; i++)
            {
                switch (i % 2)
                {
                    case 0:
                        if (goldList.First() > goldList.Last())
                        {
                            _a += goldList.First();
                            goldList = goldList.Skip(1).ToList();
                            break;
                        }
                        if (goldList.Last() > goldList.First())
                        {
                            _a += goldList.Last();
                            goldList = goldList.Take(goldList.Count() - 1).ToList();
                            break;
                        }
                        if (goldList.Last() == goldList.First())
                        {
                            _a += goldList.First();
                            goldList = goldList.Skip(1).ToList();
                        }
                        break;
                    
                    case 1:
                        if (goldList.First() > goldList.Last())
                        {
                            _b += goldList.First();
                            goldList = goldList.Skip(1).ToList();
                            break;
                        }
                        if (goldList.Last() > goldList.First())
                        {
                            _b += goldList.Last();
                            goldList = goldList.Take(goldList.Count() - 1).ToList();
                            break;
                        }
                        if (goldList.Last() == goldList.First())
                        {
                            _b += goldList.First();
                            goldList = goldList.Skip(1).ToList();
                        }
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
