using Domain;
using IDomainService;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public Account CreateAccount(int id, string userName, string userPwd, string phoneNumber)
        {
            if (_accountRepository.QueryAsync(new { UserName = userName }) != null)
            {
                throw new Exception("用户名已注册");
            }
            if (_accountRepository.QueryAsync(new { PhoneNumber = phoneNumber }) != null)
            {
                throw new Exception("手机号码已注册");
            }
            if (userPwd.Length < 6 || userPwd.Length > 16)
            {
                throw new Exception("账号密码必须大于6位数小于16位数");
            }

            return new Account(id, userName, userPwd, phoneNumber);
        }
    }
}
