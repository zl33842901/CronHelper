using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class MinuteValueHolder : ValueHolder
    {
        private MinuteValueHolder() { }

        public static MinuteValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static MinuteValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckMinutes(values);
            MinuteValueHolder result = new MinuteValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static MinuteValueHolder FromAll()
        {
            MinuteValueHolder result = new MinuteValueHolder();
            result.FromAllValue();
            return result;
        }
        public static MinuteValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckMinute(start);
            ValueChecker.CheckMinute(step);
            MinuteValueHolder result = new MinuteValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static MinuteValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckMinute(start);
            ValueChecker.CheckMinute(end);
            MinuteValueHolder result = new MinuteValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
    }
}
