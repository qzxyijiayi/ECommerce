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

        public virtual async Task<IEnumerable<TAggregationRoot>> GetByIdsAsync(IList<TAggregationRootId> aggregationRootIds)
        {
            using (Connection)
            {
                var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id in ({string.Join(',', aggregationRootIds)})";
                return await Connection.QueryAsync<TAggregationRoot>(sql, null, null);
            }
        }

        public virtual async Task<TAggregationRoot> GetByIdAsync(TAggregationRootId aggregationRootId)
        {
            using (Connection)
            {
                var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id = @Id";
                return await Connection.QueryFirstOrDefaultAsync<TAggregationRoot>(sql, new { Id = aggregationRootId }, null);
            }
        }

        public Task<TAggregationRoot> QueryAsync(dynamic condition)
        {
            throw new NotImplementedException();
        }

        public virtual async Task<int> RemoveAsync(TAggregationRoot aggregationRoot)
        {
            using (Connection)
            {
                var sql = $"Delete FROM {TableName} Where Id = @Id";
                return await Connection.ExecuteAsync(sql, new { Id = aggregationRoot.AggregationRootId }, null);
            }
        }

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
