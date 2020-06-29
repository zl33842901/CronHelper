using System;
using Xunit;

namespace xLiAd.CronHelper.Test
{
    public class UnitTestCore
    {
        [Fact]
        public void TestEveryDay()
        {
            var cron = CronHelper.EveryDay(15, 30);
            Assert.Equal("0 30 15 * * ?", cron.ToString());
            Assert.Equal("ÿ�յ�15ʱ30��0��", cron.GetDescription());
        }
        [Fact]
        public void TestEveryHour()
        {
            var cron = CronHelper.EveryHour(5, 10);
            Assert.Equal("10 5 * * * ?", cron.ToString());
            Assert.Equal("ÿʱ5��10��", cron.GetDescription());
        }
        [Fact]
        public void TestEveryMonth()
        {
            var cron = CronHelper.EveryMonth(new byte[] { 10, 20 }, 8, 20);
            Assert.Equal("0 20 8 10,20 * ?", cron.ToString());
            Assert.Equal("ÿ�µ�10��20�յ�8ʱ20��0��", cron.GetDescription());
        }
        [Fact]
        public void TestEveryYear()
        {
            var cron = CronHelper.EveryYear(1);
            Assert.Equal("0 0 0 1 1 ?", cron.ToString());
            Assert.Equal("ÿ���1��1��0ʱ0��0��", cron.GetDescription());
        }
        [Fact]
        public void TestFromTime()
        {
            var time = DateTime.Now;
            var cron = CronHelper.FromTime(time);
            Assert.Equal($"{time.Second} {time.Minute} {time.Hour} {time.Day} {time.Month} ? {time.Year}", cron.ToString());
        }
    }
}
