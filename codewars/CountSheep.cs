using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;

namespace codewars
{
    public static class Kata
    {
        public static int CountSheep(bool[] sheep)
        {
            return sheep.Count(_ => _);
        }
    }
    
    [TestFixture]
    public class CountSheepTests 
    {
        public class MyDataClass
        {   
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(new[] { true, false, true }).Returns(2);
                    yield return new TestCaseData(new[] { true,  true,  true,  false,
                                                          true,  true,  true,  true,
                                                          true,  false, true,  false,
                                                          true,  false, false, true,
                                                          true,  true,  true,  true,
                                                          false, false, true,  true }).Returns(17);
                }
            }  
        }
        
        [Test, TestCaseSource(typeof(MyDataClass), nameof(MyDataClass.TestCases))]
        public int SampleTest(bool[] sheep) 
        {
            return Kata.CountSheep(sheep);
        }
    }
}
