using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public class InterviewDto:BaseDto
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int InterviewId { get; set; }

        public string RoomName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int CompanyId { get; set; }

        public string Comments { get; set; }

        public bool Selected { get; set; }
    }

    public class UpdateInterviewDto:InterviewDto
    { }
}
