namespace codewars;

public static class CuckooClockSolution
{
    public static string CuckooClock(string inputTime, int chimes)
    {
        var time = TimeOnly.Parse(inputTime);
        var chimesCount = 0;

        if (time.Minute % 15 != 0)
        {
            time = time.AddMinutes(15 - time.Minute % 15);
        }

        while (chimesCount < chimes)
        {
            if (time.Hour == 13)
            {
                time = time.AddHours(12);
            }

            if (time.Minute > 0)
            {
                chimesCount++;
            }
            else
            {
                chimesCount += time.Hour;
            }

            if (chimesCount < chimes)
            {
                time = time.AddMinutes(15);
            }
        }

        return time.ToShortTimeString();
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
 