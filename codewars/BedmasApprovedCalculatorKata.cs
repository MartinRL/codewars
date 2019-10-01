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
                { '+', (a, b ) => a + b },
                { '/', (a, b ) => a / b },
                { '-', (a, b ) => a - b },
                { '^', Pow }
            };
            
            var expression = new string(s.Where(c => !IsWhiteSpace(c)).ToArray());

            var ss = new List<List<char>>();
            Enumerable.Range(0, expression.Count(_ => operatorMap.Keys.Contains(_)) * 2 + 1).ToList().Each(_ => ss.Add(new List<char>()));
            
            var j = 0;
            foreach (var c in expression)
            {
                if (operatorMap.Keys.Contains(c))
                {
                    j++;
                    ss.ElementAt(j).Add(c);
                    j++;
                }
                else
                {
                    ss.ElementAt(j).Add(c);    
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
        [InlineData(" 21,3 /2", 10.65)]
        [InlineData(" 7,3   -  2", 5.3)]
        [InlineData("2^3", 8)]
        public void VerifyCalculateWith(string s, double expectedCalculated)
        {
            BedmasApprovedCalculatorSolution.Calculate(s).Should().BeApproximately(expectedCalculated, 0.000000001);
        }
    }
}
