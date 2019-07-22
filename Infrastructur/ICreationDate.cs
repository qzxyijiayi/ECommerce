using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur
{
    public interface ICreationDate
    {
        /// <summary>
        /// 创建时间接口
        /// </summary>
        DateTime CreationTime { get; set; }
    }
}
