using AutoMapper;
using log4net;
using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.Interface.DataAccess;
using QuantumIT.Sample.Microservices.Interface.ORM;
using QuantumIT.Sample.Microservices.Interface.Service;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.Services.Services
{
    public class CompanyService:BaseService<CompanyDto,Company>,ICompanyService
    {
        protected readonly ICompanyRepository<Company> _companyRepository;

        public CompanyService(IUnitOfWork unitOfWork, IDBHelper idbHelper, ICompanyRepository<Company> companyRepository,IMapper mapper) : base(unitOfWork, idbHelper,mapper)
        {
            _companyRepository =companyRepository;
        }
    }
}
