using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuantumIT.Sample.Microservices.Interface.Service
{
    public interface IService<U, T>
    where U : class
    where T : class
    {

        Task<IServiceResponse<IEnumerable<U>>> GetAsync();

        Task<IServiceResponse<U>> GetByIdAsync(int id);
        Task<IServiceResponse<IEnumerable<U>>> GetRangeAsync(IEnumerable<int> Ids);

        Task<IServiceResponse<U>> AddAsync(U dto);

        Task<IServiceResponse<int>> AddRangeAsync(IEnumerable<U> dto);

        Task<IServiceResponse<int>> UpdateAsync(U dto);

        Task<IServiceResponse<int>> UpdateRangeAsync(IEnumerable<U> dto);

        Task<IServiceResponse<int>> DeleteAsync(int id);

        Task<IServiceResponse<int>> DeleteRangeAsync(IEnumerable<int> ids);

        Task<T> ExecuteWithoutTransactionAsync<T>(Func<Task<T>> action);
        Task<T> ExecuteWithTransactionAsync<T>(Func<Task<T>> action);
    }
}
