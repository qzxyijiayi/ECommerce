using Domain;
using IDomainService;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    /// <summary>
    /// 账户领域服务
    /// </summary>
    public class AccountService : IAccountService
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        /// <summary>
        /// 创建账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountName"></param>
        /// <param name="userPwd"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public Account CreateAccount(int id, string accountName, string password, string phoneNumber)
        {
            if (_accountRepository.QueryAsync(new { Name = accountName }) != null)
            {
                throw new Exception("用户名已被注册");
            }
            if (_accountRepository.QueryAsync(new { PhoneNumber = phoneNumber }) != null)
            {
                throw new Exception("手机号码已被注册");
            }

            return new Account(id, accountName, password, phoneNumber);
        }
    }
}
