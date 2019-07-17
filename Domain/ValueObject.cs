using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 值对象基类
    /// </summary>
    public class ValueObject
    {
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (this != obj) return false;
            var thisType = this.GetType();
            var objType = obj.GetType();
            if (thisType != objType) return false;
            foreach (var thisPro in thisType.GetProperties())
            {
                if (thisPro.GetValue(this) != thisPro.GetValue(obj)) return false;
            }
            return true;
        }
    }
}
