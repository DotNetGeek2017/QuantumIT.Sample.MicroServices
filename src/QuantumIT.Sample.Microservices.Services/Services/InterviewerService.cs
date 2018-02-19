using AutoMapper;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.ORM.Model;
using QuantumIT.Sample.Microservices.Services.Interface;

namespace QuantumIT.Sample.Microservices.Services.Services
{
    public class InterviewerService:BaseService<InterviewerDto,Interviewer>,IInterviewerService
    {
        protected readonly IInterviewerRepository<Interviewer> _interviewRepository;
        public InterviewerService(IUnitOfWork unitOfWork, IDBHelper idbHelper, IInterviewerRepository<Interviewer> interviewRepository, IMapper mapper) : base(unitOfWork, idbHelper, mapper)
        {
            _interviewRepository = interviewRepository;
        }
    }
}
