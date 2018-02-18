using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QuantumIT.Sample.Microservices.DataTransferObjects.Attribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ForeignKeyAttributeEx: ForeignKeyAttribute
    {
        protected readonly Type _referenceType;
        protected readonly bool _isNullable;

        public ForeignKeyAttributeEx(string name, Type referenceType) : this(name, referenceType, false)
        {
        }
        public ForeignKeyAttributeEx(string name, Type referenceType, bool isNullable) : base(name)
        {
            _referenceType = referenceType;
            _isNullable = isNullable;
        }

        public Type ReferenceType
        {
            get
            {
                return _referenceType;
            }
        }

        public bool IsNullable
        {
            get
            {
                return _isNullable;
            }
        }
    }
}
