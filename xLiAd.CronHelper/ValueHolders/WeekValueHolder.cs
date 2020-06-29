using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class WeekValueHolder : ValueHolder
    {
        private WeekValueHolder() { }

        public static WeekValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static WeekValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckWeeks(values);
            WeekValueHolder result = new WeekValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static WeekValueHolder FromAll()
        {
            WeekValueHolder result = new WeekValueHolder();
            result.FromAllValue();
            return result;
        }
        public static WeekValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckWeek(start);
            ValueChecker.CheckWeek(step);
            WeekValueHolder result = new WeekValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static WeekValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckWeek(start);
            ValueChecker.CheckWeek(end);
            WeekValueHolder result = new WeekValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
        public static WeekValueHolder FromUnknow()
        {
            WeekValueHolder result = new WeekValueHolder();
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
        public override string HolderName => "周";
        public override string HolderNameSuffix => "周";
        public override bool SuffixInFront => true;
    }
}
