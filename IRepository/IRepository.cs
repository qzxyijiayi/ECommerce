using Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace IRepository
{
    public interface IRepository<TAggregationRoot, TAggregationRootId> where TAggregationRoot : IAggregationRoot<TAggregationRootId>
    {
        Task<TAggregationRoot> QueryAsync(dynamic condition);

        Task<TAggregationRoot> GetByIdAsync(TAggregationRootId aggregationRootId);

        Task<IEnumerable<TAggregationRoot>> GetByIdsAsync(IList<TAggregationRootId> aggregationRootIds);

        Task<int> AddAsync(TAggregationRoot aggregationRoot);

        Task<int> RemoveAsync(TAggregationRoot aggregationRoot);

        Task<int> UpdateAsync(TAggregationRoot aggregationRoot);


    }
}
