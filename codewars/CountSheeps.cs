using System;
using NUnit.Framework;

namespace codewars
{
    public static class Kata
    {
        public static int CountSheeps(bool[] sheeps)
        {
            //TODO
        }
    }
    
    [TestFixture]
    public class CountSheepsTests 
    {
        [Test]
        public void SampleTest() 
        {
            var sheeps = new bool[] { true, false, true };
    
            Assert.AreEqual(2, Kata.CountSheeps(sheeps));
        }
    }
}
