using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur
{
    public class Assert
    {
        public static void IsNullOrWhiteSpace(string msg, string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new Exception($"{msg}不能为null或者空字符串");
            }
        }

        public static void IsDefault<TValue>(string msg, TValue value) where TValue : struct
        {
            if (value.Equals(default(TValue)))
            {
                throw new Exception($"{msg}不能为默认值");
            }
        }
    }
}
