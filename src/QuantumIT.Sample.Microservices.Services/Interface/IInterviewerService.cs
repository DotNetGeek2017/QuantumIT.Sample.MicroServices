using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.Interface.Service;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.Services.Interface
{
    public interface IInterviewerService:IService<InterviewerDto,Interviewer>
    {
    }
}
