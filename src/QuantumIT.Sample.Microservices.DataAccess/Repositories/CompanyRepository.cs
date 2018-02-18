using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.DataAccess.Repositories
{
    public class CompanyRepository:BaseRepository<Company>, ICompanyRepository<Company>
    {
        public CompanyRepository(IDBProvider idbProvider, IUnitOfWork unitOfWork, IRulesEngine<Company> rulesengine, IDBHelper idbHelper) : base(idbProvider, rulesengine, idbHelper)
        {
            unitOfWork.Register(this);
        }
    }
}
