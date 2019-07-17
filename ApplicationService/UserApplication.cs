using Domain;
using IApplicationService;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class UserApplication : IUserApplication
    {
        private IUserRepository _userRepository;

        private IUserIdsRepository _userIdsRepository;


        public UserApplication(IUserRepository repository)
        {
            _userRepository = repository;
        }

        public async Task<bool> CreatedUser(int id, string userName, string userPwd, string phoneNumber)
        {
            var userIds = _userIdsRepository.Query(Guid.NewGuid());
            if (!userIds.Equals(id)) return await Task.FromResult(false);
            var user = new User(id, userName, userPwd, phoneNumber);
            return await _userRepository.AddAscyn(user) > 0;
        }

        public async Task<bool> UpdateUserPwd(int id, string userPwd)
        {
            var user = _userRepository.Query(id);
            user.UpdatePwd(userPwd);
            return await _userRepository.UpdateAsync(user) > 0;
        }
    }
}
