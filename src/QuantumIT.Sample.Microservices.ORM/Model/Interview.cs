using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.ORM.Model
{
    public class Interview: BaseModel
    {
        public int InterviewId { get; set; }

        public string RoomName { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime? EndDateTime { get; set; }

        public int CompanyId { get; set; }

        public string Comments { get; set; }

        public bool Selected { get; set; }
    }
}
