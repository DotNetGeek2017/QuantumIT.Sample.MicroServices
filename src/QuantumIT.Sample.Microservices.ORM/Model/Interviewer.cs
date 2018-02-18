using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.ORM.Model
{
    public class Interviewer:BaseModel
    {
        public int InterviewerId { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public int InterviewId { get; set; }

    }
}
