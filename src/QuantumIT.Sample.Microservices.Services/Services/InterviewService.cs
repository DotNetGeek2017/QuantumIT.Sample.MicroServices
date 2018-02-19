using AutoMapper;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;
using QuantumIT.Sample.Microservices.Services.Interface;

namespace QuantumIT.Sample.Microservices.Services.Services
{
    public class InterviewService:BaseService<InterviewDto,Interview>,IInterviewService
    {
        protected readonly IInterviewRepository<Interview> _interviewRepository;

        public InterviewService(IUnitOfWork unitOfWork, IDBHelper idbHelper, IInterviewRepository<Interview> interviewRepository, IMapper mapper) : base(unitOfWork, idbHelper, mapper)
        {
            _interviewRepository = interviewRepository;
        }
    }
}
