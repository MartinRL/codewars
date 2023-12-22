namespace codewars;

public static class CuckooClockSolution
{
    public static string CuckooClock(string time, int chimes)
    {
        var hAndM = time.Split(':').Select(int.Parse);
        var h = hAndM.First();
        var m = hAndM.Last();
        
        chimes -= m % 15 == 0 ? m == 0 ? h : 1 : 0;
        while (chimes > 0)
        {
            m += 15;
            if (m >= 60)
            {
                h++;
                m %= 60;
                if (h > 12)
                {
                    h %= 12;
                }
                chimes -= h - 1;
            }

            chimes--;
        }

        m -= m % 15;
        
        return $"{h:d2}:{m:d2}";
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
 