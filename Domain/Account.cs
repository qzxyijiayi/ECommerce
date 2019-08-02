using Infrastructur;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Account : AggregationRoot
    {
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

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string PhoneNumber { get; private set; }

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
