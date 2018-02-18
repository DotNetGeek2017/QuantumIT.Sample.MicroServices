using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.DTO
{
    public class InterviewerDto:BaseDto
    {
        public int InterviewerId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int InterviewId { get; set; }
    }
}
