using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IApplicationService
{
    public interface IAccountApplication
    {
        Task<bool> CreatedAccount(int id, string userName, string userPwd, string phoneNumber);

        Task<bool> ChangeAccountPassword(int id, string userPwd);
    }
}
