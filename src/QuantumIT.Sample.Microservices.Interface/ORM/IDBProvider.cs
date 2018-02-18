using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QuantumIT.Sample.Microservices.Interface.ORM
{
    public interface IDBProvider : IDisposable
    {
        Task OpenConnectionAsync();
        void CloseConnection();
        Task<IDbTransaction> InitTransactionAsync(IsolationLevel isolationLevel);
        void CommitTransaction();
        void RollbackTransaction();
        Task<int> AddAsync<T>(T entity);
        Task<int> AddAsync<T>(T entity, string[] ignoreParameters);
        Task<int> AddRangeAsync<T>(IEnumerable<T> entity);
        Task<int> AddRangeAsync<T>(IEnumerable<T> entities, string[] ignoreParameters = null);
        Task<int> AddRangeWithQueryAsync<T>(string query, IEnumerable<T> entities, string[] ignoreParameters = null);
        Task<int> UpdateRangeAsync<T>(IEnumerable<T> entities, string[] ByIds, string[] ignoreParameters = null);
        Task<int> UpdateAsync<T>(T entity, string[] ignoreParameters = null);

        Task<int> UpdateWithoutCOALSCEAsync<T>(T entity, string[] ignoreParameters = null);
        Task<IEnumerable<T>> GetAsync<T>(bool enabled = true);
        Task<T> GetByIdAsync<T>(string id, string keyName, bool enabled = true);
        Task<IEnumerable<T>> GetAsync<T>(string query, object param);
        Task<int> DeleteAsync<T>(int entityId, string[] ignoreParameters = null);
        Task<IDictionary<Type, IEnumerable<object>>> QueryMultiple(string query, object parameters, IEnumerable<Type> returnTypes);

        Task<IEnumerable<T>> GetByQuery<Q, S, T>(string query, Func<Q, S, T> map, object param = null, string splitOn = "Id");

        Task<IEnumerable<T>> GetByQuery<Q, R, S, T>(string query, Func<Q, R, S, T> map, object param = null, string splitOn = "Id");
    }
}
