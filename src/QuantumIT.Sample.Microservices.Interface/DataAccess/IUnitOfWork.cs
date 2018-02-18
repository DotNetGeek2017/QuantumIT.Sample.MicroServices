using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IUnitOfWork
    {
        Dictionary<Type, dynamic> repos { get; }
        Task OpenConnectionAsync();
        void CloseConnection();
        Task StartTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);
        void CompleteTransaction();
        void Error();
        dynamic Repository<T>() where T : class;
        void Register<T>(IRepository<T> repository) where T : class;
    }
}
