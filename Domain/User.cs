using Infrastructur;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User : AggregationRoot, ICreationDate, IModificationDate
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="phoneNumber"></param>
        public User(int id, string name, string password, string phoneNumber) : base(id)
        {
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }

        public string Password { get; private set; }

        public string PhoneNumber { get; private set; }
        public DateTime CreationTime { get; set; }
        public DateTime ModificationTime { get; set; }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userPwd"></param>
        public void UpdatePwd(string userPwd)
        {
            var pwdMd5 = MD5Helper.GetMD5(userPwd);
            this.Password = pwdMd5;
        }
    }
}
