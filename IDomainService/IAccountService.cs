using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IDomainService
{
    public interface IAccountService
    {
        Account CreateAccount(int id, string accountName, string password, string phoneNumber);
    }
}
