using Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IRepository<TAggregationRoot, TAggregationRootId> where TAggregationRoot : IAggregationRoot<TAggregationRootId>
    {
        TAggregationRoot Query(TAggregationRootId aggregationRootId);

        IEnumerable<TAggregationRoot> Query(IList<TAggregationRootId> aggregationRootIds);

        int Add(TAggregationRoot aggregationRoot);

        int Add(IList<TAggregationRoot> aggregationRoot);

        int Remove(TAggregationRoot aggregationRoot);

        int Remove(IList<TAggregationRoot> aggregationRoots);

        Task<TAggregationRoot> QueryAsync(TAggregationRootId aggregationRootId);

        Task<IEnumerable<TAggregationRoot>> QueryAscyn(IList<TAggregationRootId> aggregationRootIds);

        Task<int> AddAscyn(TAggregationRoot aggregationRoot);

        Task<int> AddAscyn(IList<TAggregationRoot> aggregationRoot);

        Task<int> RemoveAscyn(TAggregationRoot aggregationRoot);

        Task<int> RemoveAscyn(IList<TAggregationRoot> aggregationRoots);


    }
}
