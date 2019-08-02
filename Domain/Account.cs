using Infrastructur;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    /// <summary>
    /// 账户聚合根
    /// </summary>
    public class Account : AggregationRoot
    {
        /// <summary>
        /// 创建账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="phoneNumber"></param>
        public Account(int id, string name, string password, string phoneNumber) : base(id)
        {
            Assert.IsDefault("账户Id", id);
            Assert.IsNullOrWhiteSpace("账户名", name);
            Assert.IsNullOrWhiteSpace("账户密码", password);
            Assert.IsNullOrWhiteSpace("账户手机号", phoneNumber);
            if (password.Length < 6 || password.Length > 16)
            {
                throw new Exception("账号密码必须大于6位数小于16位数");
            }
            var pwdMd5 = MD5Helper.GetMD5(password);
            Name = name;
            Password = pwdMd5;
            PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// 账户名
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 账户密码
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// 账户手机号
        /// </summary>
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        public void UpdatePassword(string password)
        {
            Assert.IsNullOrWhiteSpace("账户密码", password);
            if (password.Length < 6 || password.Length > 16)
            {
                throw new Exception("账户密码必须大于6位数小于16位数");
            }
            var pwdMd5 = MD5Helper.GetMD5(password);
            this.Password = pwdMd5;
        }
    }
}
