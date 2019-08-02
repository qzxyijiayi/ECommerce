using Dapper;
using Domain;
using Infrastructur;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// 仓储基类
    /// </summary>
    /// <typeparam name="TAggregationRoot"></typeparam>
    /// <typeparam name="TAggregationRootId"></typeparam>
    public abstract class Repository<TAggregationRoot, TAggregationRootId> : IRepository<TAggregationRoot, TAggregationRootId>
        where TAggregationRoot : AggregationRoot<TAggregationRootId>
    {

        protected IDbConnection Connection
        {
            get
            {
                var conn = new SqlConnection(ConfigSettings.SqlConnationString);
                conn.Open();
                return conn;
            }
        }

        public string TableName { private get; set; } = typeof(TAggregationRoot).Name;

        /// <summary>
        /// 添加聚合根
        /// </summary>
        /// <param name="aggregationRoot"></param>
        /// <returns></returns>
        public virtual async Task<int> AddAsync(TAggregationRoot aggregationRoot)
        {
            using (Connection)
            {
                var sql = "Insert Into{0} Values({1})";
                var _sqlSnippets = aggregationRoot.GetType().GetProperties().Select(pro => $"{pro.Name} = @{pro.GetValue(aggregationRoot)}");
                var sqlSb = new StringBuilder();
                sqlSb = sqlSb.AppendJoin(',', _sqlSnippets);
                return await Connection.ExecuteAsync(string.Format(sql, TableName, sqlSb.ToString()), aggregationRoot, null);
            }
        }

        /// <summary>
        /// 通过聚合根Id获取聚合根
        /// </summary>
        /// <param name="aggregationRootIds"></param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<TAggregationRoot>> GetByIdsAsync(IList<TAggregationRootId> aggregationRootIds)
        {
            using (Connection)
            {
                var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id in ({string.Join(',', aggregationRootIds)})";
                return await Connection.QueryAsync<TAggregationRoot>(sql, null, null);
            }
        }

        /// <summary>
        /// 通过聚合根Id集合获取聚合根
        /// </summary>
        /// <param name="aggregationRootId"></param>
        /// <returns></returns>
        public virtual async Task<TAggregationRoot> GetByIdAsync(TAggregationRootId aggregationRootId)
        {
            using (Connection)
            {
                var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id = @Id";
                return await Connection.QueryFirstOrDefaultAsync<TAggregationRoot>(sql, new { Id = aggregationRootId }, null);
            }
        }

        /// <summary>
        /// 通过条件获取聚合根
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public virtual async Task<TAggregationRoot> QueryAsync(object condition)
        {
            using (Connection)
            {
                var sqlFragments = condition.GetType().GetProperties().Select(u => string.Format("{0} = @{0}", u.Name));
                var sqlFragmentJoin = string.Join(" And ", sqlFragments);
                var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where {sqlFragmentJoin}";
                return await Connection.QueryFirstOrDefaultAsync<TAggregationRoot>(sql, condition, null);
            }
        }

        /// <summary>
        /// 移除聚合根
        /// </summary>
        /// <param name="aggregationRoot"></param>
        /// <returns></returns>
        public virtual async Task<int> RemoveAsync(TAggregationRoot aggregationRoot)
        {
            using (Connection)
            {
                var sql = $"Delete FROM {TableName} Where Id = @Id";
                return await Connection.ExecuteAsync(sql, new { Id = aggregationRoot.AggregationRootId }, null);
            }
        }

        /// <summary>
        /// 修改聚合根
        /// </summary>
        /// <param name="aggregationRoot"></param>
        /// <returns></returns>
        public virtual async Task<int> UpdateAsync(TAggregationRoot aggregationRoot)
        {
            using (Connection)
            {
                var _sqlSnippets = aggregationRoot.GetType().GetProperties().Select(pro => $"{pro.Name} = @{pro.GetValue(aggregationRoot)}");
                var sql = $"Update {TableName} Set {_sqlSnippets} Where Id = @AggregationRootId";
                return await Connection.ExecuteAsync(sql, aggregationRoot);
            }
        }

    }
}
