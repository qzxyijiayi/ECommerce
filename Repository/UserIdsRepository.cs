using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IRepository;

namespace Repository
{
    public class UserIdsRepository : Repository<UserIds, Guid>, IUserIdsRepository
    {
        public override UserIds GetById(Guid aggregationRootId)
        {
            var ids = Connection.Query<long>("Select id from UserIds").ToList();
            return new UserIds(aggregationRootId, ids);
        }
    }
}
