using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;

namespace QuantumIT.Sample.Microservices.DataAccess
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool disposedValue = false;
        private IDBProvider _idbProvider;
        public Dictionary<Type, dynamic> repos { get; private set; }

        public UnitOfWork(IDBProvider idbProvider)
        {
            _idbProvider = idbProvider;
            repos = new Dictionary<Type, dynamic>();
        }

        public Task OpenConnectionAsync()
        {
            return _idbProvider.OpenConnectionAsync();
        }

        public void CloseConnection()
        {
            _idbProvider.CloseConnection();
        }

        public Task StartTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted)
        {
            return _idbProvider.InitTransactionAsync(isolationLevel);
        }

        public void CompleteTransaction()
        {
            _idbProvider.CommitTransaction();
        }

        public void Error()
        {
            _idbProvider.RollbackTransaction();
        }

        public dynamic Repository<T>() where T : class
        {
            dynamic repository;
            if (repos.TryGetValue(typeof(T), out repository))
            {
                return repository;
            }
            return null;
        }

        public void Register<T>(IRepository<T> repository) where T : class
        {
            dynamic repositoryValue;
            if (!repos.TryGetValue(typeof(T), out repositoryValue))
            {
                repos.Add(typeof(T), repository);
            }
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _idbProvider.Dispose();
                    _idbProvider = null;
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }

         
    }

}
