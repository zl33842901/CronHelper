using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    public abstract class ValueHolder<T> where T : struct
    {
        /// <summary>
        /// 类型
        /// </summary>
        public ValueHolderTypeEnum ValueHolderType { get; set; }
        public bool AllOrUnknown => ValueHolderType == ValueHolderTypeEnum.All || ValueHolderType == ValueHolderTypeEnum.UnKnown;
        /// <summary>
        /// 当 ValueHolderType 是 ValueArray 时，数组的值。
        /// </summary>
        public T[] ArrayValues { get; set; }
        /// <summary>
        /// 当 ValueHolderType 是 StartStep、SerialValue 时，Start 的值
        /// </summary>
        public T Start { get; set; }
        /// <summary>
        /// 当 ValueHolderType 是 StartStep 时，Step 的值
        /// </summary>
        public T Step { get; set; }
        /// <summary>
        /// 当 ValueHolderType 是 SerialValue 时，End 的值
        /// </summary>
        public T End { get; set; }

        protected void FromArrayValues(T[] values)
        {
            this.ValueHolderType = ValueHolderTypeEnum.ValueArray;
            if (values == null || values.Length < 1)
                this.ArrayValues = new T[] { default(T) };
            else
                this.ArrayValues = values;
        }
        protected void FromAllValue()
        {
            this.ValueHolderType = ValueHolderTypeEnum.All;
        }
        protected void FromStartStepValue(T start, T step)
        {
            this.ValueHolderType = ValueHolderTypeEnum.StartStep;
            this.Start = start;
            this.Step = step;
        }
        protected void FromSerialValue(T start, T end)
        {
            this.ValueHolderType = ValueHolderTypeEnum.SerialValue;
            this.Start = start;
            this.End = end;
        }
        public override string ToString()
        {
            switch (ValueHolderType)
            {
                case ValueHolderTypeEnum.All:
                    return "*";
                case ValueHolderTypeEnum.SerialValue:
                    return $"{Start}-{End}";
                case ValueHolderTypeEnum.StartStep:
                    return $"{Start}/{Step}";
                case ValueHolderTypeEnum.ValueArray:
                    return string.Join(",", ArrayValues);
                default:
                    throw new Exception($"未知的{nameof(ValueHolderType)}：{ValueHolderType}");
            }
        }

        public abstract string HolderName { get; }
        public abstract string HolderNameSuffix { get; }
        public virtual bool SuffixInFront => false;

        public virtual string GetDescription()
        {
            switch (ValueHolderType)
            {
                case ValueHolderTypeEnum.All:
                    return "每" + HolderName;
                case ValueHolderTypeEnum.SerialValue:
                    if (SuffixInFront)
                        return $"{HolderNameSuffix}{Start}-{HolderNameSuffix}{End}";
                    else
                        return $"{Start}-{End}{HolderNameSuffix}";
                case ValueHolderTypeEnum.StartStep:
                    if (SuffixInFront)
                        return $"从{HolderNameSuffix}{Start}开始每{Step}天";
                    else
                        return $"从{Start}{HolderNameSuffix}开始每{Step}{HolderNameSuffix}";
                case ValueHolderTypeEnum.UnKnown:
                    return string.Empty;
                case ValueHolderTypeEnum.ValueArray:
                    if (SuffixInFront)
                        return HolderNameSuffix + string.Join("、", ArrayValues);
                    else
                        return string.Join("、", ArrayValues) + HolderNameSuffix;
                default:
                    throw new Exception($"未知的{nameof(ValueHolderType)}：{ValueHolderType}");
            }
        }
    }


    public abstract class ValueHolder : ValueHolder<byte>
    {

    }
}
