using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public class InterviewerDto:BaseDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InterviewerId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int InterviewId { get; set; }
    }

    public class UpdateInterviewerDto : InterviewDto
    {

    }
}
