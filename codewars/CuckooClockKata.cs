namespace codewars;

public class CuckooClock
{
    public TimeOnly Time;
    public int Chimes = 0;

    public CuckooClock(TimeOnly time)
    {
        Time = time;
        
        SetChimes();
        
        SetTimeToLastChime();
    }

    private void SetChimes()
    {
        if (Time.Minute == 0)
        {
            var hour = Time.Hour > 12 ? Time.Hour % 12 : Time.Hour; 
            Chimes += hour;
        }
        else if (Time.Minute % 15 == 0)
        {
            Chimes += 1;
        }
    }

    private void SetTimeToLastChime()
    {
        Time = Time.Minute <= 15 ? 
            Time.AddMinutes(-Time.Minute) : 
            Time.AddMinutes(-Time.Minute % 15);
    }

    public void Chime()
    {
        Time = Time.AddMinutes(15);
        
        SetChimes();
    }
}

public class CuckooClockSolution
{
    public static string CuckooClock(string time, int chimes)
    {
        CuckooClock cuckooClock = new (TimeOnly.Parse(time));

        while (cuckooClock.Chimes < chimes)
        {
            cuckooClock.Chime();
        }

        return $"{(cuckooClock.Time.Hour != 12 ? cuckooClock.Time.Hour % 12 : cuckooClock.Time.Hour).ToString().PadLeft(2, '0')}:{cuckooClock.Time.Minute.ToString().PadLeft(2, '0')}";
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
        [InlineData("10:00", 1, "10:00")]
        [InlineData("10:00", 10, "10:00")]
        [InlineData("10:00", 11, "10:15")]
        [InlineData("10:00", 13, "10:45")]
        [InlineData("10:00", 20, "11:00")]
        [InlineData("12:30", 1, "12:30")]
        [InlineData("12:30", 2, "12:45")]
        [InlineData("12:30", 3, "01:00")]
        [InlineData("12:30", 4, "01:15")]
        [InlineData("09:53", 50, "02:30")]
        [InlineData("08:17", 113, "08:00")]
        [InlineData("08:17", 114, "08:15")]
        [InlineData("08:17", 115, "08:30")]
        [InlineData("08:17", 150, "11:00")]
        [InlineData("08:17", 200, "05:45")]
        public void VerifyCuckooClockWith(string time, int chimes, string expectedTime) => CuckooClockSolution.CuckooClock(time, chimes).Should().Be(expectedTime);
    }

/* tests from https://www.codewars.com/kata/656e4602ee72af0017e37e82
 *  [Test]
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
 