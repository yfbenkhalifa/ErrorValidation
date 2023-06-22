using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public class Validation : IValidation
    {
        private bool _isValid;
        
        private IEnumerable<ValidationCheck> _checks;
        public IEnumerable<ValidationCheck> GetValidationChecks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationError> GetValidationErrors()
        {
            
        }

        public IEnumerable<ValidationError> GetWarnings()
        {
            throw new NotImplementedException();
        }

        public bool IsValidated() => _isValid;

        public bool Validate()
        {
           _isValid = true;
            foreach (ValidationCheck check in _checks) { 
                bool checkValidated = check.Validate();

                if (_isValid) _isValid = checkValidated;
            }

            return _isValid;
        }
    }

    public class ValidationResult { 
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
    public class ValidationCheck : IValidationCheck
    {
        public IEnumerable<ValidationError> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public bool IsValidated()
        {
            throw new NotImplementedException();
        }

        public bool Validate()
        {
            throw new NotImplementedException();
        }
    }

    public class ValidationError
    {
        private string Description { get; set; }
        private string Message { get; set; }
    }
}
