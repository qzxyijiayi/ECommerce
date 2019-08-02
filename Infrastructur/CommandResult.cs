using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructur
{
    /// <summary>
    /// 应用层统一返回结果
    /// </summary>
    public class CommandResult
    {
        public CommandResult(bool success, string msg)
        {
            Success = success;
            Msg = msg;
        }
        public CommandResult(bool success, string msg, object date)
        {
            Success = success;
            Msg = msg;
            Date = date;
        }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; private set; }

        /// <summary>
        /// 异常说明
        /// </summary>
        public string Msg { get; private set; }

        public object Date { get; private set; }

        public static CommandResult SuccessResult()
        {
            return new CommandResult(true, null);
        }

        public static CommandResult SuccessResult(string msg)
        {
            return new CommandResult(true, msg);
        }

        public static CommandResult SuccessResult(string msg, object date)
        {
            return new CommandResult(true, msg, date);
        }

        public static CommandResult Failed(string msg)
        {
            return new CommandResult(true, msg);
        }
    }
}
