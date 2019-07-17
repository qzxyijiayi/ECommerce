using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRepository
{
    public interface IUserIdsRepository : IRepository<UserIds, Guid>
    {
    }
}
