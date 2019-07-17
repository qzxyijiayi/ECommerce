using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IAggregationRoot<TAggregationRootId> : IEntity<TAggregationRootId>
    {
    }

    public interface IAggregationRoot : IAggregationRoot<int>, IEntity
    {
    }
}
