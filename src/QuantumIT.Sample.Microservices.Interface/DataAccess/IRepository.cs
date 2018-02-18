using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetByIdRangeAsync(IEnumerable<int> ids);
        Task<T> GetByIdAsync(int id, string keyName);
        Task<IEnumerable<T>> GetByQueryAsync(string query, object param = null);
        Task<int> AddAsync(T entity);
        Task<int> AddAsync(T entity, List<string> ignoreFields);
        Task<int> AddRangeAsync(IEnumerable<T> entities);

        Task<int> AddRangeAsync(IEnumerable<T> entities, List<string> ignoreParameters);
        Task<int> UpdateAsync(T entity);
        Task<int> UpdateAsync(T entity, List<string> ignoreParameters);
        Task<int> UpdateAsync(T entity, List<string> ignoreFields, bool Coalsce);

        Task<int> UpdateRangeAsync(IEnumerable<T> entities);
        Task<int> UpdateRangeAsync(IEnumerable<T> entities, string[] byKeys);
        Task<int> UpdateRangeAsync(IEnumerable<T> entities, string[] byKeys, List<string> ignoreParameters);

        Task<int> RemoveAsync(int id);
        Task<int> RemoveRangeAsync(IEnumerable<int> ids);
        Task<IEnumerable<IDataValidationFailure>> CanAddAsync(T entity);
        Task<IEnumerable<IDataValidationFailure>> CanUpdateAsync(T entity);
        Type TableType { get; }
        Task<IEnumerable<T>> GetWithQuery<Q, S, T>(string query, Func<Q, S, T> map, object param, string splitOn);
        Task<IEnumerable<T>> GetWithQuery<Q, R, S, T>(string query, Func<Q, R, S, T> map, object param, string splitOn);

        Task<IDictionary<Type, IEnumerable<object>>> QueryMultiple(string query, object parameters, IEnumerable<Type> returnTypes);
    }
}
