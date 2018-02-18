using Microsoft.AspNetCore.Mvc;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.Interface.Service;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.MicroServices.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController:BaseController<CompanyDto,Company,UpdateCompanyDto>
    {
        public CompanyController(ICompanyService companyService):base(companyService)
        {
        }
    }
}
