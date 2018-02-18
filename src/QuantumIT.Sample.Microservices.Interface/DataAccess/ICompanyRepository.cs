using System.Threading.Tasks;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface ICompanyRepository<T> : IRepository<T> where T : class
    {
    }
}
