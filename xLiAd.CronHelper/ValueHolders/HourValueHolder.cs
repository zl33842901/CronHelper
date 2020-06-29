using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class HourValueHolder : ValueHolder
    {
        private HourValueHolder() { }

        public static HourValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static HourValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckHours(values);
            HourValueHolder result = new HourValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static HourValueHolder FromAll()
        {
            HourValueHolder result = new HourValueHolder();
            result.FromAllValue();
            return result;
        }
        public static HourValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckHour(start);
            ValueChecker.CheckHour(step);
            HourValueHolder result = new HourValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static HourValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckHour(start);
            ValueChecker.CheckHour(end);
            HourValueHolder result = new HourValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
    }
}
