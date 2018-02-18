using QuantumIT.Sample.Microservices.DataTransferObjects.DTO;
using QuantumIT.Sample.Microservices.ORM.Model;

namespace QuantumIT.Sample.Microservices.Interface.Service
{
    public interface ICompanyService: IService<CompanyDto, Company>
    {
    }
}
