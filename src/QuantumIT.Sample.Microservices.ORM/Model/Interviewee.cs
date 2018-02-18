using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.ORM.Model
{
    public class Interviewee:BaseModel
    {
        public int IntervieweeId { get; set; }

        public string Name { get; set; }

        public string ApplyingRole { get; set; }

        public int InterviewId { get; set; }
    }
}
