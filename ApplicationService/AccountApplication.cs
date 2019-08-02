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

        private IAccountService _accountService;


        public AccountApplication(IAccountRepository repository)
        {
            _userRepository = repository;
        }

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

        public async Task<CommandResult> ChangeAccountPassword(int id, string password)
        {
            try
            {
                var account = await _userRepository.GetByIdAsync(id);
                if (account == null) throw new Exception("没有该用户");
                account.UpdatePassword(password);
                if (await _userRepository.UpdateAsync(account) > 0) return CommandResult.SuccessResult("修改成功", account);
                else return CommandResult.Failed("修改失败");
            }
            catch (Exception ex)
            {
                return CommandResult.Failed(ex.ToString());
            }
        }
    }
}
