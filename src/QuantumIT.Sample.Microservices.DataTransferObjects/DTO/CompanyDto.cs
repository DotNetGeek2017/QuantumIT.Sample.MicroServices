using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public class CompanyDto:BaseDto
    {

        public int CompanyId { get; set; }
        public string Name { get; set; }
    }

    public class UpdateCompanyDto : CompanyDto
    {

    }
}
