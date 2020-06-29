using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public class YearValueHolder : ValueHolder<ushort>
    {
        private YearValueHolder() { }

        public static YearValueHolder FromValue(ushort value)
        {
            return FromArray(new ushort[] { value });
        }
        public static YearValueHolder FromArray(ushort[] values)
        {
            ValueChecker.CheckYears(values);
            YearValueHolder result = new YearValueHolder();
            result.FromArrayValues(values);
            return result;
        }
        public static YearValueHolder FromAll()
        {
            YearValueHolder result = new YearValueHolder();
            result.FromAllValue();
            return result;
        }
        public static YearValueHolder FromStartStep(ushort start, ushort step)
        {
            ValueChecker.CheckYear(start);
            ValueChecker.CheckYear(step);
            YearValueHolder result = new YearValueHolder();
            result.FromStartStepValue(start, step);
            return result;
        }
        public static YearValueHolder FromSerial(ushort start, ushort end)
        {
            ValueChecker.CheckYear(start);
            ValueChecker.CheckYear(end);
            YearValueHolder result = new YearValueHolder();
            result.FromSerialValue(start, end);
            return result;
        }
    }
}
