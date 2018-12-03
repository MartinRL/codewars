using System;
using NUnit.Framework;

namespace codewars
{
    public static class Kata
    {
        public static int CountSheep(bool[] sheep)
        {
            //TODO
        }
    }
    
    [TestFixture]
    public class CountSheepTests 
    {
        [Test]
        public void SampleTest() 
        {
            var sheep = new bool[] { true, false, true };
    
            Assert.AreEqual(2, Kata.CountSheep(sheep));
        }
    }
}
