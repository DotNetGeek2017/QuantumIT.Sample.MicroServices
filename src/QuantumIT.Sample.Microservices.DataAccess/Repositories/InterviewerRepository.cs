using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.DataAccess.Repositories
{
    public class InterviewerRepository:BaseRepository<Interviewer>,IInterviewerRepository<Interviewer>
    {
        public InterviewerRepository(IDBProvider idbProvider, IUnitOfWork unitOfWork, IRulesEngine<Interviewer> rulesengine, IDBHelper idbHelper) : base(idbProvider, rulesengine, idbHelper)
        {
            unitOfWork.Register(this);
        }
    }
}
