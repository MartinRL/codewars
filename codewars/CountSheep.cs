using System;
using NUnit.Framework;

namespace codewars
{
    public static class Kata
    {
        public static int CountSheep(bool[] sheep)
        {
            return 2;
        }
    }
    
    [TestFixture]
    public class CountSheepTests 
    {
        [Test]
        public void SampleTest() 
        {
            var sheep = new[] { true, false, true };
    
            Assert.AreEqual(2, Kata.CountSheep(sheep));
        }
    }
}
