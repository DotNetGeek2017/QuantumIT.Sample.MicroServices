using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.DataAccess.Repositories
{
    public class InterviewRepository:BaseRepository<Interview>,IInterviewRepository<Interview>
    {
        public InterviewRepository(IDBProvider idbProvider, IUnitOfWork unitOfWork, IRulesEngine<Interview> rulesengine, IDBHelper idbHelper) : base(idbProvider, rulesengine, idbHelper)
        {
            unitOfWork.Register(this);
        }
    }
}
