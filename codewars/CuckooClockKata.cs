namespace codewars;

public class CuckooClock
{
    public byte Hour;
    public byte Minutes;
    public uint Chimes = 0;

    public CuckooClock(string time)
    {
        var hourAndMinutes = time.Split(':').Select(byte.Parse);
        Hour = hourAndMinutes.First();
        Minutes = hourAndMinutes.Last();
        
        UpdateChimes();
        SetMinutesToLastChime();
    }

    private void UpdateChimes()
    {
        if (Minutes == 0)
        {
            Chimes += Hour;
        }
        else if (Minutes % 15 == 0)
        {
            Chimes += 1;
        }
    }

    private void SetMinutesToLastChime() => Minutes -= Convert.ToByte(Minutes % 15);

    public void Chime()
    {
        UpdateTime();
        UpdateChimes();
    }

    private void UpdateTime()
    {
        Minutes += 15;

        if (Minutes != 60) return;
        
        Minutes = 0;
        Hour += 1;
            
        if (Hour == 13)
        {
            Hour = 1;
        }
    }
}

public static class CuckooClockSolution
{
    public static string CuckooClock(string time, int chimes)
    {
        CuckooClock cuckooClock = new (time);

        while (cuckooClock.Chimes < chimes)
        {
            cuckooClock.Chime();
        }

        return $"{cuckooClock.Hour.ToString().PadLeft(2, '0')}:{cuckooClock.Minutes.ToString().PadLeft(2, '0')}";
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
 