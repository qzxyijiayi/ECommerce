using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class UserIds : AggregationRoot<Guid>
    {
        public UserIds(Guid id, List<long> ids) : base(id)
        {
            Ids = ids;
        }


        public List<long> Ids { get; private set; }

        public bool Exists(long id)
        {
            return Ids.Contains(id);
        }
    }
}
