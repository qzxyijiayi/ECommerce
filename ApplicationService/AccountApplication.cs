using Domain;
using IApplicationService;
using IDomainService;
using Infrastructur;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class AccountApplication : IAccountApplication
    {
        private IAccountRepository _userRepository;

        private IAccountDomainService _accountService;

        public AccountApplication(IAccountRepository userRepository, IAccountDomainService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        /// <summary>
        /// 注册账户
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountName"></param>
        /// <param name="password"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public async Task<CommandResult> CreatedAccount(int id, string accountName, string password, string phoneNumber)
        {
            try
            {
                var account = _accountService.CreateAccount(id, accountName, password, phoneNumber);
                if (await _userRepository.AddAsync(account) > 0) return CommandResult.SuccessResult("注册成功", account);
                else return CommandResult.Failed("注册失败");
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(ex.ToString());
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<CommandResult> ChangeAccountPassword(int id, string password)
        {
            try
            {
                var account = await _userRepository.GetByIdAsync(id);
                if (account == null) throw new Exception("没有该用户");
                account.UpdatePassword(password);
                if (await _userRepository.UpdateAsync(account) > 0) return CommandResult.SuccessResult("修改密码成功", account);
                else return CommandResult.Failed("修改密码失败");
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(ex.ToString());
            }
        }
    }
}
