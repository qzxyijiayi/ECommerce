using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IApplicationService
{
    public interface IUserApplication
    {
        Task<bool> CreatedUser(int id, string userName, string userPwd, string phoneNumber);

        Task<bool> UpdateUserPwd(int id, string userPwd);
    }
}
