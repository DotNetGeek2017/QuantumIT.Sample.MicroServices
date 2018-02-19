using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public class IntervieweeDto:BaseDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IntervieweeId { get; set; }

        public string Name { get; set; }

        public string ApplyingRole { get; set; }

        public int InterviewId { get; set; }
    }
}
