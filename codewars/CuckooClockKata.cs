namespace codewars;

public class CuckooClock
{
    public readonly TimeOnly Time;
    public int Chimes = 0;

    public CuckooClock(TimeOnly time)
    {
        Time = time;
        
        if (Time.Minute == 0)
        {
            Chimes += Time.Hour;
        }
        else if (Time.Minute % 15 == 0)
        {
            Chimes += 1;
        }
    }

    public void Chime()
    {
        throw new NotImplementedException();
    }
}

public class CuckooClockSolution
{
    public static string CuckooClock(string time, int chimes)
    {
        CuckooClock cuckooClock = new (TimeOnly.Parse(time));

        do
        {
            cuckooClock.Chime();
        } while (cuckooClock.Chimes <= chimes);
        
        return cuckooClock.Time.ToString();
    }
}

public class CuckooClockTests
    {
        [Theory]
        [InlineData("07:22", 1, "07:30")]
        [InlineData("12:22", 2, "12:45")]
        [InlineData("01:30", 2, "01:45")]
        [InlineData("04:01", 10, "05:30")]
        [InlineData("03:38", 19, "06:00")]
        public void VerifyCuckooClockWith(string time, int chimes, string expectedTime) => CuckooClockSolution.CuckooClock(time, chimes).Should().Be(expectedTime);
    }

/* tests from https://www.codewars.com/kata/656e4602ee72af0017e37e82
 * [Test]
    public void SimpleTests()
    {
          List<string> initialTimes = new List<string> { "07:22", "12:22", "01:30", "04:01", "03:38" };
          List<int> chimes = new List<int> { 1, 2, 2, 10, 19 };
          List<string> expectedTimes = new List<string> { "07:30", "12:45", "01:45", "05:30", "06:00" };

          for (int i = 0; i < initialTimes.Count; i++)
          {
              Assert.AreEqual(expectedTimes[i], CuckooClockSolution.CuckooClock(initialTimes[i], chimes[i]));
          }
    }
    
    [Test]
    public void HourTests() // Test case where the starting time is 00, i.e. on the hour
    {
          List<string> initialTimes = new List<string> { "10:00", "10:00", "10:00", "10:00", "10:00" };
          List<int> chimes = new List<int> { 1, 10, 11, 13, 20 };
          List<string> expectedTimes = new List<string> { "10:00", "10:00", "10:15", "10:45", "11:00" };

          for (int i = 0; i < initialTimes.Count; i++)
          {
              Assert.AreEqual(expectedTimes[i], CuckooClockSolution.CuckooClock(initialTimes[i], chimes[i]));
          }
    }
  
    [Test]
    public void TwelveTests() // Test going from twelve to one
    {
          List<string> initialTimes = new List<string> { "12:30", "12:30", "12:30", "12:30", "09:53" };
          List<int> chimes = new List<int> { 1, 2, 3, 4, 50 };
          List<string> expectedTimes = new List<string> { "12:30", "12:45", "01:00", "01:15", "02:30" };

          for (int i = 0; i < initialTimes.Count; i++)
          {
              Assert.AreEqual(expectedTimes[i], CuckooClockSolution.CuckooClock(initialTimes[i], chimes[i]));
          }
    }
  
    [Test]
    public void AroundTheClockTests() // Test going more than 12 hours ahead
    {
          List<string> initialTimes = new List<string> { "08:17", "08:17", "08:17", "08:17", "08:17" };
          List<int> chimes = new List<int> { 113, 114, 115, 150, 200 };
          List<string> expectedTimes = new List<string> { "08:00", "08:15", "08:30", "11:00", "05:45" };

          for (int i = 0; i < initialTimes.Count; i++)
          {
              Assert.AreEqual(expectedTimes[i], CuckooClockSolution.CuckooClock(initialTimes[i], chimes[i]));
          }
    }
 */
 