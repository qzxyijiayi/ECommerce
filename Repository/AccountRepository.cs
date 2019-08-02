using Domain;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    /// <summary>
    /// 账户仓储
    /// </summary>
    public class AccountRepository : Repository<Account, int>, IAccountRepository
    {
    }
}
