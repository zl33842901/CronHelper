using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class MonthValueHolder : ValueHolder
    {
        private MonthValueHolder() { }

        public static MonthValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static MonthValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckMonths(values);
            MonthValueHolder result = new MonthValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static MonthValueHolder FromAll()
        {
            MonthValueHolder result = new MonthValueHolder();
            result.FromAllValue();
            return result;
        }
        public static MonthValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckMonth(start);
            ValueChecker.CheckMonth(step);
            MonthValueHolder result = new MonthValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static MonthValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckMonth(start);
            ValueChecker.CheckMonth(end);
            MonthValueHolder result = new MonthValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
        public override string HolderName => "月";
        public override string HolderNameSuffix => "月";
    }
}
