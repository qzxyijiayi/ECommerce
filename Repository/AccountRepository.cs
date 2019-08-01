using Domain;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class AccountRepository : Repository<Account, int>, IAccountRepository
    {
    }
}
