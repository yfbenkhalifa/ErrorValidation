using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public class Validation<Entity> : IValidation<Entity>
    {
        private bool _isValid;

        public IEnumerable<IValidationCheck<Entity>> _checks;

        public Validation()
        {
            _checks = new List<IValidationCheck<Entity>>();
        }

        public void AddValidationCheck(IValidationCheck<Entity> check)
        {
            if (_checks == null) _checks = new List<IValidationCheck<Entity>>();
            _checks = _checks.Append(check);
        }
        public void RemoveValidationCheck(IValidationCheck<Entity> check) => _checks = _checks.Where(x => !x.Equals(check));
        
        public IEnumerable<IValidationCheck<Entity>> GetValidationChecks() => _checks;

        public IEnumerable<IValidationError> GetValidationErrors()
        {
            var errors = new List<IValidationError>();
            foreach (var check in _checks) {
                if (!check.IsValidated()) errors.Add(check.Error);
            }
            return errors;
        }

        public IEnumerable<ValidationError> GetWarnings()
        {
            throw new NotImplementedException();
        }

        public bool IsValidated() => _isValid;

        public bool Validate(Entity e)
        {
            _isValid = true;
            
            foreach (IValidationCheck<Entity> check in _checks) {
                bool checkValidated = check.Validate(e);
                
                if (_isValid) _isValid = checkValidated;
            }

            return _isValid;
        }

        IEnumerable<IValidationError> IValidation<Entity>.GetWarnings()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<string> GetErrorMessages()
        {
            foreach(var check in _checks)
                yield return check.Error.ToString();
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

    public class ValidationCheck<Entity> : IValidationCheck<Entity>
    {
        private IValidationCondition<Entity> _condition;
        private IValidationError _error;
        public IValidationError Error { get => _error; set => _error = value; }

        public ValidationCheck(IValidationCondition<Entity> condition, IValidationError error)
        {
            _condition = condition;
            _error = error;
        }

        public bool IsValidated() => _condition.IsVerified();

        public bool Validate(Entity e)
        {
            bool checkVerified = _condition.Verify(e);
            return checkVerified;
        }

    }

    public class ValidationError : IValidationError
    {
        private string Description { get; set; }
        private string Message { get; set; }

        public ValidationError(string description, string message)
        {
            Description = description;
            Message = message;
        }
        public override string ToString()
        {
            return $"\n{Description}: {Message}";
        }
        public string GetErrorMessage() => Message;
    }
}
