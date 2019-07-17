using Domain;
using IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class UserRepository : Repository<User, long>, IUserRepository
    {
    }
}
