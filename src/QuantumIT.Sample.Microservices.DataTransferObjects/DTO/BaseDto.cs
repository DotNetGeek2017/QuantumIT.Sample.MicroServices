using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public abstract class BaseDto
    {
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool Enabled { get; set; }
    }
}
