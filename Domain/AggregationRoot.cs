using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public abstract class AggregationRoot<TAggregationRootId> : IAggregationRoot
    {
        public TAggregationRootId AggregationRootId { get; protected set; }

        protected AggregationRoot(TAggregationRootId id)
        {
            AggregationRootId = id;
        }

    }
}
