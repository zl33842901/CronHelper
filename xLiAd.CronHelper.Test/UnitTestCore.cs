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
            Assert.Equal("每日的15时30分0秒", cron.GetDescription());
        }
        [Fact]
        public void TestEveryHour()
        {
            var cron = CronHelper.EveryHour(5, 10);
            Assert.Equal("10 5 * * * ?", cron.ToString());
            Assert.Equal("每时5分10秒", cron.GetDescription());
        }
        [Fact]
        public void TestEveryMonth()
        {
            var cron = CronHelper.EveryMonth(new byte[] { 10, 20 }, 8, 20);
            Assert.Equal("0 20 8 10,20 * ?", cron.ToString());
            Assert.Equal("每月的10、20日的8时20分0秒", cron.GetDescription());
        }
        [Fact]
        public void TestEveryYear()
        {
            var cron = CronHelper.EveryYear(1);
            Assert.Equal("0 0 0 1 1 ?", cron.ToString());
            Assert.Equal("每年的1月1日0时0分0秒", cron.GetDescription());
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
