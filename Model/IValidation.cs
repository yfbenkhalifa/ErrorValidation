using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public interface IValidation
    {
        public bool Validate();
        public bool IsValidated();
        public IEnumerable<ValidationError> GetValidationErrors();
        public IEnumerable<ValidationError> GetWarnings();
        public IEnumerable<ValidationError> GetValidationChecks();
        

    }
    public interface IValidationCheck { 
        public bool Validate();
        public bool IsValidated();
        public IEnumerable<ValidationError> GetValidationErrors();
    }
}
