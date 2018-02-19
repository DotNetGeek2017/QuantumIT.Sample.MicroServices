using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuantumIT.Sample.Microservices.DataTransferObjects.Attribute;

namespace QuantumIT.Sample.Microservices.ORM.Model
{
    public class Interview: BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InterviewId { get; set; }

        public string RoomName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        [ForeignKeyAttributeEx("CompanyId", typeof(Company))]
        public int CompanyId { get; set; }

        public string Comments { get; set; }

        public bool Selected { get; set; }
    }
}
