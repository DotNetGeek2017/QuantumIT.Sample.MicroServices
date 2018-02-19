using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuantumIT.Sample.Microservices.DataTransferObjects.Attribute;

namespace QuantumIT.Sample.Microservices.ORM.Model
{
    public class Interviewee:BaseModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IntervieweeId { get; set; }

        public string Name { get; set; }

        public string ApplyingRole { get; set; }

        [ForeignKeyAttributeEx("InterviewId", typeof(Interview))]
        public int InterviewId { get; set; }
    }
}
