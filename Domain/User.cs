using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : AggregationRoot
    {
        public User(int id, string name, string password, string phoneNumber) : base(id)
        {
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public void UpdatePwd(string userPwd)
        {
            var pwdMd5 = MD5Helper.GetMD5(userPwd);
            this.Password = pwdMd5;
        }
    }
}
