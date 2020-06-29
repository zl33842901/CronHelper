using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    /// <summary>
    /// 日期   暂不支持 L  W  等
    /// </summary>
    public class DayValueHolder : ValueHolder
    {
        private DayValueHolder() { }

        public static DayValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static DayValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckDays(values);
            DayValueHolder result = new DayValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static DayValueHolder FromAll()
        {
            DayValueHolder result = new DayValueHolder();
            result.FromAllValue();
            return result;
        }
        public static DayValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckDay(start);
            ValueChecker.CheckDay(step);
            DayValueHolder result = new DayValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static DayValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckDay(start);
            ValueChecker.CheckDay(end);
            DayValueHolder result = new DayValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
        public static DayValueHolder FromUnknow()
        {
            DayValueHolder result = new DayValueHolder();
            result.ValueHolderType = ValueHolderTypeEnum.UnKnown;
            return result;
        }
        public override string ToString()
        {
            if (this.ValueHolderType == ValueHolderTypeEnum.UnKnown)
                return "?";
            else
                return base.ToString();
        }

        public override string HolderName => "天";
        public override string HolderNameSuffix => "日";
    }
}