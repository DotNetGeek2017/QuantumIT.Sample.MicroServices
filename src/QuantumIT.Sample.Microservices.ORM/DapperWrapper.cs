using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using QuantumIT.Sample.Microservices.Interface.ORM;

namespace QuantumIT.Sample.Microservices.ORM
{
    public class DapperWrapper : IDapperWrapper
    {
        public async Task<int> ExecuteAsync(System.Data.IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return await cnn.ExecuteAsync(sql, param, transaction, commandTimeout);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(System.Data.IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return await cnn.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType).ConfigureAwait(false);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?))
        {
            return await cnn.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> Query<Q, S, T>(IDbConnection cnn, Func<Q, S, T> map, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?), string spliton = "Id")
        {
            return await cnn.QueryAsync<Q, S, T>(sql, map, param, transaction, buffered, spliton, commandTimeout, commandType);
        }

        public async Task<IEnumerable<T>> Query<Q, R, S, T>(IDbConnection cnn, Func<Q, R, S, T> map, string sql, object param = null, IDbTransaction transaction = null, bool buffered = true, int? commandTimeout = default(int?), CommandType? commandType = default(CommandType?), string spliton = "Id")
        {
            return await cnn.QueryAsync<Q, R, S, T>(sql, map, param, transaction, buffered, spliton, commandTimeout, commandType);
        }

        Task<SqlMapper.GridReader> IDapperWrapper.QueryMultipleAsync(IDbConnection cnn, string sql, object param, IDbTransaction transaction, int? commandTimeout, CommandType? commandType)
        {
            throw new NotImplementedException();
        }
    }
}
