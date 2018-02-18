using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumIT.Sample.Microservices.Interface.DataAccess
{
    public interface IDataValidationFailure
    {
        string Name { get; set; }
        string ErrorMessage { get; set; }
    }
}
