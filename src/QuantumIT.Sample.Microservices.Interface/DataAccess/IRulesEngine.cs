using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IRulesEngine<T> where T:class
    {
        T AddEntity(T entity);

        IEnumerable<T> AddEntities(IEnumerable<T> entities);

        T UpdateEntity(T entity);

        IEnumerable<T> UpdateEntities(IEnumerable<T> entities);

        T RemoveEntity(T entity);
    }
}
