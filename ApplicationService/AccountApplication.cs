using Domain;
using IApplicationService;
using IDomainService;
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

        public async Task<bool> CreatedAccount(int id, string userName, string userPwd, string phoneNumber)
        {
            var user = _accountService.CreateAccount(id, userName, userPwd, phoneNumber);
            return await _userRepository.AddAsync(user) > 0;
        }

        public async Task<bool> ChangeAccountPassword(int id, string userPwd)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new Exception("没用该用户");
            user.UpdatePwd(userPwd);
            return await _userRepository.UpdateAsync(user) > 0;
        }
    }
}
