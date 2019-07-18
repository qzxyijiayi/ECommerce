using Dapper;
using Domain;
using Infrastructur;
using IRepository;
using System;
using System.Collections.Generic;
using System.Data;
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

        public IDbTransaction Transaction { private get; set; } = null;

        public virtual int Add(TAggregationRoot aggregationRoot)
        {
            var sql = "Insert Into{0} Values({1})";
            var _sqlSnippets = aggregationRoot.GetType().GetProperties().Select(pro => $"{pro.Name} = @{pro.GetValue(aggregationRoot)}");
            var sqlSb = new StringBuilder();
            sqlSb = sqlSb.AppendJoin(',', _sqlSnippets);
            return Connection.Execute(string.Format(sql, TableName, sqlSb.ToString()), aggregationRoot, Transaction);
        }

        public virtual int Add(IList<TAggregationRoot> aggregationRoots)
        {
            var i = 0;
            foreach (var aggregationRoot in aggregationRoots)
            {
                i += Add(aggregationRoot);
            }
            return i;
        }

        public virtual async Task<int> AddAscyn(TAggregationRoot aggregationRoot)
        {
            var sql = "Insert Into{0} Values({1})";
            var _sqlSnippets = aggregationRoot.GetType().GetProperties().Select(pro => $"{pro.Name} = @{pro.GetValue(aggregationRoot)}");
            var sqlSb = new StringBuilder();
            sqlSb = sqlSb.AppendJoin(',', _sqlSnippets);
            return await Connection.ExecuteAsync(string.Format(sql, TableName, sqlSb.ToString()), aggregationRoot, Transaction);
        }
        public virtual async Task<int> AddAscyn(IList<TAggregationRoot> aggregationRoots)
        {
            var i = 0;
            foreach (var aggregationRoot in aggregationRoots)
            {
                i += await AddAscyn(aggregationRoot);
            }
            return i;
        }

        public virtual TAggregationRoot Query(TAggregationRootId aggregationRootId)
        {
            var sql = $"SELECT * FROM {TableName} Where Id = @Id";
            return Connection.QueryFirstOrDefault<TAggregationRoot>(sql, new { Id = aggregationRootId }, Transaction);
        }

        public virtual IEnumerable<TAggregationRoot> Query(IList<TAggregationRootId> aggregationRootIds)
        {
            var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id in ({string.Join(',', aggregationRootIds)})";
            return Connection.Query<TAggregationRoot>(sql, null, Transaction);
        }

        public virtual async Task<IEnumerable<TAggregationRoot>> QueryAscyn(IList<TAggregationRootId> aggregationRootIds)
        {
            var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id in ({string.Join(',', aggregationRootIds)})";
            return await Connection.QueryAsync<TAggregationRoot>(sql, null, Transaction);
        }

        public virtual async Task<TAggregationRoot> QueryAsync(TAggregationRootId aggregationRootId)
        {
            var sql = $"SELECT * FROM {typeof(TAggregationRoot).Name} Where Id = @Id";
            return await Connection.QueryFirstOrDefaultAsync<TAggregationRoot>(sql, new { Id = aggregationRootId }, Transaction);
        }



        public virtual int Remove(TAggregationRoot aggregationRoot)
        {
            var sql = $"Delete FROM {TableName} Where Id = @Id";
            return Connection.Execute(sql, new { Id = aggregationRoot.AggregationRootId }, Transaction);
        }

        public virtual int Remove(IList<TAggregationRoot> aggregationRoots)
        {
            var i = 0;
            foreach (var aggregationRoot in aggregationRoots)
            {
                i += Remove(aggregationRoot);
            }
            return i;
        }



        public virtual async Task<int> RemoveAscyn(TAggregationRoot aggregationRoot)
        {
            var sql = $"Delete FROM {TableName} Where Id = @Id";
            return await Connection.ExecuteAsync(sql, new { Id = aggregationRoot.AggregationRootId }, Transaction);
        }

        public virtual async Task<int> RemoveAscyn(IList<TAggregationRoot> aggregationRoots)
        {
            var i = 0;
            foreach (var aggregationRoot in aggregationRoots)
            {
                i += await RemoveAscyn(aggregationRoot);
            }
            return i;
        }

        public virtual int Update(TAggregationRoot aggregationRoot)
        {
            using (Connection)
            {
                var _sqlSnippets = aggregationRoot.GetType().GetProperties().Select(pro => $"{pro.Name} = @{pro.GetValue(aggregationRoot)}");
                var sql = $"Update {TableName} Set {_sqlSnippets} Where Id = @AggregationRootId";
                return Connection.Execute(sql, aggregationRoot);
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
