using System;
using System.Collections.Generic;
using System.Text;
using QuantumIT.Sample.Microservices.Interface.DataAccess;

namespace QuantumIT.Sample.Microservices.DataAccess.Validation
{
    public class DataValidationFailure: IDataValidationFailure
    {
        public string ErrorMessage
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }
    }
}
