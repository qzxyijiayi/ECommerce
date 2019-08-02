using Infrastructur;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IApplicationService
{
    public interface IAccountApplication
    {
        Task<CommandResult> CreatedAccount(int id, string accountName, string password, string phoneNumber);

        Task<CommandResult> ChangeAccountPassword(int id, string password);
    }
}
