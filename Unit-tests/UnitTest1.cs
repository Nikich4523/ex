namespace trgdfetgtr;

public class UnitTest1
{
    [Fact]
            public void GetPeriods_TimeFrom_Return7And21And2Periods()
            {
                //возвращает 7 периодов
                TimeSpan[] startTimes = { TimeSpan.FromHours(9), TimeSpan.FromHours(10.5), TimeSpan.FromHours(12), new TimeSpan(15, 30, 0), new TimeSpan(17, 0, 0) };
                int[] durations = { 60, 60, 20, 10, 30 };
                var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 40);
                Assert.Equal(7, test.Length);
                
                //возвращает 21 период
                TimeSpan[] startTimes2 = { TimeSpan.FromHours(10), TimeSpan.FromHours(11), TimeSpan.FromHours(15), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
                int[] durations2 = { 60, 30, 10, 10, 40 };
                var test2 = Calculations.AvailablePeriods(startTimes2, durations2, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 20);
                Assert.Equal(21, test2.Length);
    
                //вовзращает 2 периода
                TimeSpan[] startTimes3 = { TimeSpan.FromHours(8), TimeSpan.FromHours(10), TimeSpan.FromHours(12), new TimeSpan(13, 30, 0), TimeSpan.FromHours(14),
                    new TimeSpan(16, 50, 0), new TimeSpan(17, 20, 0) };
                int[] durations3 = { 60, 25, 15, 50, 40, 15, 30 };
                var test3 = Calculations.AvailablePeriods(startTimes3, durations3, TimeSpan.FromHours(8), TimeSpan.FromHours(18), 90);
                Assert.Equal(2, test3.Length);
            }
            
            [Fact]
            public void GetAvailablePeriods_NoBusyRanges_Return0Periods()
            {
                //пусто(возвращает 0 периодов)
                TimeSpan[] startTimes = { TimeSpan.FromHours(8) };
                int[] durations = { 60 };
    
                var test = Calculations.AvailablePeriods(startTimes, durations, TimeSpan.FromHours(8), TimeSpan.FromHours(9.5), 90);
    
                Assert.Empty(test);
            }
}