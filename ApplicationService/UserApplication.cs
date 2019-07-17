using Domain;
using IApplicationService;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService
{
    public class UserApplication : IUserApplication
    {
        private IUserRepository _repository;


        public UserApplication(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool CreatedUser(long id, string userName, string userPwd)
        {
            var userIds = _repository.Query(Guid.NewGuid());
            if (!userIds.Equals(id)) return false;
            var user = new User(id, userName, userPwd);
            return _repository.Add(user) > 0;
        }

        public bool UpdateUserPwd(long id, string userPwd)
        {
            var user = _repository.Query(id);
            user.UpdatePwd(userPwd);
            return _repository.UpdatePwd(user) > 0;
        }
    }
}
