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

        private IEnumerable<IValidationCheck> _checks;

        public IEnumerable<IValidationCheck> GetValidationChecks()
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
        public ValidationResult(string message)
        {
            Message = message;
        }

        public bool IsValid { get; set; }
        public string Message { get; set; }


    }


    public class ValidationCondition<Entity> : IValidationCondition<Entity>{
        private bool _isVerified;

        public Func<Entity, bool> ConditionCheck { get; set; }
        

        public ValidationCondition(Func<Entity, bool> conditionCheck)
        {
            _isVerified = false;
            ConditionCheck = conditionCheck;
        }

        public bool Verify(Entity e)
        {
            _isVerified = ConditionCheck(e);
            return _isVerified;
        }

        public bool IsVerified() => _isVerified;
    }

    public class ValidationCheck<Entity> : IValidationCheck
    {
        private ValidationResult _result;
        private ValidationCondition<Entity> _condition;

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
            
        }
    }

    public class ValidationError
    {
        private string Description { get; set; }
        private string Message { get; set; }
    }
}
