using System;
using System.ComponentModel;
using System.Text;
using xLiAd.CronHelper.ValueHolders;

namespace xLiAd.CronHelper
{
    public class CronHelper
    {
        public SecondValueHolder SecondValue { get; private set; }
        public MinuteValueHolder MinuteValue { get; private set; }
        public HourValueHolder HourValue { get; private set; }
        public DayValueHolder DayValue { get; private set; }
        public WeekValueHolder WeekValue { get; private set; }
        public MonthValueHolder MonthValue { get; private set; }
        public YearValueHolder YearValue { get; private set; }
        public CronHelper(SecondValueHolder secondValue, MinuteValueHolder minuteValue, HourValueHolder hourValue, DayValueHolder dayValue, WeekValueHolder weekValue, MonthValueHolder monthValue, YearValueHolder yearValue)
        {
            this.SecondValue = secondValue;
            this.MinuteValue = minuteValue;
            this.HourValue = hourValue;
            this.DayValue = dayValue;
            this.WeekValue = weekValue;
            this.MonthValue = monthValue;
            this.YearValue = yearValue;
        }

        public static CronHelper EveryMinute(byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromAll(),
                HourValueHolder.FromAll(),
                DayValueHolder.FromAll(),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromAll(),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryMinute(byte second = 0) => EveryMinute(new byte[] { second });

        public static CronHelper EveryHour(byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromAll(),
                DayValueHolder.FromAll(),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromAll(),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryHour(byte[] minutes, byte second = 0) => EveryHour(minutes, new byte[] { second });
        public static CronHelper EveryHour(byte minute = 0, byte second = 0) => EveryHour(new byte[] { minute }, new byte[] { second });

        public static CronHelper EveryDay(byte[] hours, byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromArray(hours),
                DayValueHolder.FromAll(),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromAll(),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryDay(byte[] hours, byte minute = 0, byte second = 0) => EveryDay(hours, new byte[] { minute }, new byte[] { second });
        public static CronHelper EveryDay(byte hour = 0, byte minute = 0, byte second = 0) => EveryDay(new byte[] { hour }, new byte[] { minute }, new byte[] { second });

        public static CronHelper EveryMonth(byte[] days, byte[] hours, byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromArray(hours),
                DayValueHolder.FromArray(days),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromAll(),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryMonth(byte[] days, byte hour = 0, byte minute = 0, byte second = 0) => EveryMonth(days, new byte[] { hour }, new byte[] { minute }, new byte[] { second });
        public static CronHelper EveryMonth(byte day, byte hour = 0, byte minute = 0, byte second = 0) => EveryMonth(new byte[] { day }, new byte[] { hour }, new byte[] { minute }, new byte[] { second });

        public static CronHelper EveryWeek(byte[] weekdays, byte[] hours, byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromArray(hours),
                DayValueHolder.FromUnknow(),
                WeekValueHolder.FromArray(weekdays),
                MonthValueHolder.FromAll(),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryWeek(byte[] weekdays, byte hour = 0, byte minute = 0, byte second = 0) => EveryWeek(weekdays, new byte[] { hour }, new byte[] { minute }, new byte[] { second });
        public static CronHelper EveryWeek(byte weekday, byte hour = 0, byte minute = 0, byte second = 0) => EveryWeek(new byte[] { weekday }, new byte[] { hour }, new byte[] { minute }, new byte[] { second });

        public static CronHelper EveryYear(byte[] months, byte[] days, byte[] hours, byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromArray(hours),
                DayValueHolder.FromArray(days),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromArray(months),
                YearValueHolder.FromAll());
            return result;
        }
        public static CronHelper EveryYear(byte[] months, byte day = 1, byte hour = 0, byte minute = 0, byte second = 0) => EveryYear(months, new byte[] { day }, new byte[] { hour }, new byte[] { minute }, new byte[] { second });
        public static CronHelper EveryYear(byte month, byte day = 1, byte hour = 0, byte minute = 0, byte second = 0) => EveryYear(new byte[] { month }, new byte[] { day }, new byte[] { hour }, new byte[] { minute }, new byte[] { second });

        public static CronHelper FromTimes(ushort[] years, byte[] months, byte[] days, byte[] hours, byte[] minutes, byte[] seconds)
        {
            CronHelper result = new CronHelper(
                SecondValueHolder.FromArray(seconds),
                MinuteValueHolder.FromArray(minutes),
                HourValueHolder.FromArray(hours),
                DayValueHolder.FromArray(days),
                WeekValueHolder.FromUnknow(),
                MonthValueHolder.FromArray(months),
                YearValueHolder.FromArray(years));
            return result;
        }

        public static CronHelper FromTime(ushort year, byte month = 1, byte day = 1, byte hour = 0, byte minute = 0, byte second = 0)
        {
            var result = FromTimes(new ushort[] { year }, new byte[] { month }, new byte[] { day }, new byte[] { hour }, new byte[] { minute }, new byte[] { second });
            return result;
        }

        public static CronHelper FromTime(DateTime dateTime) => FromTime((ushort)dateTime.Year, (byte)dateTime.Month, (byte)dateTime.Day, (byte)dateTime.Hour, (byte)dateTime.Minute, (byte)dateTime.Second);


        public override string ToString()
        {
            var result = $"{this.SecondValue} {this.MinuteValue} {this.HourValue} {this.DayValue} {this.MonthValue} {this.WeekValue}";
            if (this.YearValue.ValueHolderType != ValueHolderTypeEnum.All)
                result += $" {this.YearValue}";
            return result;
        }

        public string GetDescription()
        {
            StringBuilder sb = new StringBuilder();
            if (!this.YearValue.AllOrUnknown || !this.MonthValue.AllOrUnknown)
                sb.Append($"{this.YearValue.GetDescription()}的");
            if (!this.YearValue.AllOrUnknown || !this.MonthValue.AllOrUnknown || !this.DayValue.AllOrUnknown || !this.WeekValue.AllOrUnknown)
                sb.Append($"{this.MonthValue.GetDescription()}的");
            if (!this.YearValue.AllOrUnknown || !this.MonthValue.AllOrUnknown || !this.HourValue.AllOrUnknown || !this.WeekValue.AllOrUnknown)
                if (this.WeekValue.ValueHolderType != ValueHolderTypeEnum.UnKnown)
                    sb.Append($"{this.WeekValue.GetDescription()}的");
            if (!this.YearValue.AllOrUnknown || !this.MonthValue.AllOrUnknown || !this.DayValue.AllOrUnknown || !this.HourValue.AllOrUnknown)
                if (this.DayValue.ValueHolderType != ValueHolderTypeEnum.UnKnown)
                    sb.Append($"{this.DayValue.GetDescription()}的");
            if (this.HourValue.AllOrUnknown)
                sb.Append($"{this.HourValue.GetDescription()}的");
            else
                sb.Append($"{this.HourValue.GetDescription()}");
            sb.Append($"{this.MinuteValue.GetDescription()}{this.SecondValue.GetDescription()}");
            return sb.ToString();
        }
    }
}
