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
            var pwdMd5 = MD5Helper.GetMD5(password);
            Name = name;
            Password = pwdMd5;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string PhoneNumber { get; private set; }

        public void UpdatePwd(string userPwd)
        {
            var pwdMd5 = MD5Helper.GetMD5(userPwd);
            this.Password = pwdMd5;
        }
    }
}
