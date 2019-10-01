using System;
using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static System.Char;
using FluentAssertions;
using Xunit;

namespace codewars
{
    public class BedmasApprovedCalculatorSolution
    {
        public static double Calculate(string s)
        {
            var operatorMap = new Dictionary<char, Func<double, double, double>>
            {
                { '*', (a, b) => a * b },
                { '+', (a, b ) => a + b }
            };
            
            var expression = new string(s.Where(c => !IsWhiteSpace(c)).ToArray());

            // 3 = # of operators + number of terms
            var ss = new List<List<char>> // 2do: Enumerable.Range
            {
                new List<char>(),
                new List<char>(),
                new List<char>()
            };
            
            var j = 0;
            for (var i = 0; i < expression.Length; i++)
            {
                if (operatorMap.Keys.Contains(expression[i])) // 2do: hole in the middle
                {
                    j++;
                    ss.ElementAt(j).Add(expression[i]);
                    j++;
                }
                else
                {
                    ss.ElementAt(j).Add(expression[i]);    
                }
            }

            var sss = ss.Select(_ => (operatorMap.Keys.Contains(_.First())) ? _.First().ToString() : new string(_.ToArray()));

            return operatorMap[sss.ElementAt(1).First()](double.Parse(sss.ElementAt(0)), double.Parse(sss.ElementAt(2)));
        }
    }

    public class BedmasApprovedCalculatorTests
    {
        [Theory]
        [InlineData("1 + 2", 3)]
        [InlineData("2*2", 4)]
        public void VerifyCalculateWith(string s, double expectedCalculated)
        {
            BedmasApprovedCalculatorSolution.Calculate(s).Should().BeApproximately(expectedCalculated, 0.000000001);
        }
    }
}
