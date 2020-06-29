using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class SecondValueHolder : ValueHolder
    {
        private SecondValueHolder() { }

        public static SecondValueHolder FromValue(byte value)
        {
            return FromArray(new byte[] { value });
        }
        public static SecondValueHolder FromArray(byte[] values)
        {
            ValueChecker.CheckSeconds(values);
            SecondValueHolder result = new SecondValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static SecondValueHolder FromAll()
        {
            SecondValueHolder result = new SecondValueHolder();
            result.FromAllValue();
            return result;
        }
        public static SecondValueHolder FromStartStep(byte start, byte step)
        {
            ValueChecker.CheckSecond(start);
            ValueChecker.CheckSecond(step);
            SecondValueHolder result = new SecondValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static SecondValueHolder FromSerial(byte start, byte end)
        {
            ValueChecker.CheckSecond(start);
            ValueChecker.CheckSecond(end);
            SecondValueHolder result = new SecondValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
        public override string HolderName => "秒";
        public override string HolderNameSuffix => "秒";
    }
}
