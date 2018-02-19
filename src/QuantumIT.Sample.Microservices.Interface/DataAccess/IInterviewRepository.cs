using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IInterviewRepository<T>: IRepository<T> where T : class
    {
    }
}
