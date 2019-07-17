using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationService
{
    public interface IDomainFactory<TAggregationRoot, TAggregationRootId> where TAggregationRoot : AggregationRoot<TAggregationRootId>
    {
        TAggregationRoot GetDomain(TAggregationRootId aggregationRootId);
    }
}
