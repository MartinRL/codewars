namespace codewars
{
    public class AreYouPlayingBanjoSolution
    {
        public static string AreYouPlayingBanjo(string name)
        {
            //Implement me
        }
    }
    
    public class AreYouPlayingBanjoTests
    {
        [Test]
        public static void Martin()
        {
            Assert.AreEqual("Martin does not play banjo", Kata.AreYouPlayingBanjo("Martin"));
        }
  
        [Test]
        public static void Rikke()
        {
            Assert.AreEqual("Rikke plays banjo", Kata.AreYouPlayingBanjo("Rikke"));
        }
    }
}
