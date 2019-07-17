using System;
using System.Collections.Generic;
using System.Text;

namespace IApplicationService
{
    public interface IUserApplication
    {
        bool CreatedUser(long id, string userName, string userPwd);

        bool UpdateUserPwd(long id, string userPwd);
    }
}
