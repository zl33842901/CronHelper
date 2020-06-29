using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper
{
    public static class ValueChecker
    {
        public static void CheckSecond(byte second)
        {
            if (second > 59)
                throw new ArgumentOutOfRangeException(nameof(second), "秒的取值范围：0~59");
        }
        public static void CheckSeconds(IEnumerable<byte> seconds)
        {
            foreach (var second in seconds)
                CheckSecond(second);
        }

        public static void CheckMinute(byte minute)
        {
            if (minute > 59)
                throw new ArgumentOutOfRangeException(nameof(minute), "分钟的取值范围：0~59");
        }

        public static void CheckMinutes(IEnumerable<byte> minutes)
        {
            foreach (var minute in minutes)
                CheckMinute(minute);
        }

        public static void CheckHour(byte hour)
        {
            if (hour > 23)
                throw new ArgumentOutOfRangeException(nameof(hour), "小时的取值范围：0~23");
        }

        public static void CheckHours(IEnumerable<byte> hours)
        {
            foreach (var hour in hours)
                CheckHour(hour);
        }

        public static void CheckDay(byte day)
        {
            if(day < 1 || day > 31)
                throw new ArgumentOutOfRangeException(nameof(day), "天的取值范围：1~31");
        }
        public static void CheckDays(IEnumerable<byte> days)
        {
            foreach (var day in days)
                CheckDay(day);
        }

        public static void CheckWeek(byte week)
        {
            if (week < 1 || week > 7)
                throw new ArgumentOutOfRangeException(nameof(week), "周的取值范围：1~7");
        }

        public static void CheckWeeks(IEnumerable<byte> weeks)
        {
            foreach (var week in weeks)
                CheckWeek(week);
        }

        public static void CheckMonth(byte month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "月的取值范围：1~12");
        }

        public static void CheckMonths(IEnumerable<byte> months)
        {
            foreach (var month in months)
                CheckMonth(month);
        }

        public static void CheckYear(ushort year)
        {
            if (year < 2000 || year > 2099)
                throw new ArgumentOutOfRangeException(nameof(year), "年的取值范围：2000~2099");
        }

        public static void CheckYears(IEnumerable<ushort> years)
        {
            foreach (var year in years)
                CheckYear(year);
        }
    }
}
