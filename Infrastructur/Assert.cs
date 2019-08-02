using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur
{
    /// <summary>
    /// 断言
    /// </summary>
    public class Assert
    {
        /// <summary>
        /// 可空断言
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="title"></param>
        public static void IsNullOrWhiteSpace(string msg, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception($"{msg}不能为null或者空字符串");
            }
        }

        /// <summary>
        /// 值类型默认值断言
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="msg"></param>
        /// <param name="value"></param>
        public static void IsDefault<TValue>(string msg, TValue value) where TValue : struct
        {
            if (value.Equals(default(TValue)))
            {
                throw new Exception($"{msg}不能为默认值");
            }
        }
    }
}
