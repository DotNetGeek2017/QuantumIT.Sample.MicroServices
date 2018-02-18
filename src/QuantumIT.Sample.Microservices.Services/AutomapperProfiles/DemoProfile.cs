using AutoMapper;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.Services.AutomapperProfiles
{
    public class DemoProfile:Profile
    {
        public DemoProfile()
        {
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<InterviewDto, Interview>().ReverseMap();
            CreateMap<IntervieweeDto, Interviewee>().ReverseMap();
            CreateMap<InterviewerDto, Interviewer>().ReverseMap();
        }
    }
}
