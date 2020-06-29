using System;
using System.Collections.Generic;
using System.Text;

namespace xLiAd.CronHelper.ValueHolders
{
    /// <summary>
    /// 值的类型
    /// </summary>
    public enum ValueHolderTypeEnum : byte
    {
        /// <summary>
        /// 全部，代表 *
        /// </summary>
        All = 0,
        /// <summary>
        /// 数组形式  1,2,3
        /// </summary>
        ValueArray = 1,
        /// <summary>
        /// 开始/间隔形式   0/30
        /// </summary>
        StartStep = 2,
        /// <summary>
        /// 连续值形式   0-10
        /// </summary>
        SerialValue = 3,
        /// <summary>
        /// 天 星期 使用，代表 ?
        /// </summary>
        UnKnown = 4
    }
}
