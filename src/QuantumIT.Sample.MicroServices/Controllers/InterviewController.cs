using Microsoft.AspNetCore.Mvc;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.ORM.Model;
using QuantumIT.Sample.Microservices.Services.Interface;

namespace QuantumIT.Sample.MicroServices.Controllers
{
    [Route("api/[controller]")]
    public class InterviewController : BaseController<InterviewDto, Interview, UpdateInterviewDto> { 
    
        public InterviewController(IInterviewService interviewService):base(interviewService)
        {
        }
    }
}
