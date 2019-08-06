using Infrastructur.OutDto.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IQueryService
{
    public interface IAccountQueryService
    {
        Task<LoginOutDto> Login(string accountName, string password);
    }
}
