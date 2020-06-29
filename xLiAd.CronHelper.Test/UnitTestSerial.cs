using System;
using Xunit;

namespace xLiAd.CronHelper.Test
{
    public class UnitTestSerial
    {
        [Fact]
        public void TestSerial1()
        {
            var cron = CronHelper.EveryDay(15, 30);
            var cronJsonString = Newtonsoft.Json.JsonConvert.SerializeObject(cron);
            var cron2 = Newtonsoft.Json.JsonConvert.DeserializeObject<CronHelper>(cronJsonString);
            Assert.Equal(cron.ToString(), cron2.ToString());
        }
    }
}
