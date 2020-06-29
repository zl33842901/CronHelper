using System;
using Xunit;

namespace xLiAd.CronHelper.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var cron = CronHelper.EveryDay(15, 30);
            Assert.Equal("0 30 15 * * ?", cron.ToString());
        }
    }
}
