using ErrorValidation.UnitTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public class PiValidation : IValidation<Pi>
    {
        private IEnumerable<IValidation<Pi>> _validations;
        private bool _isValidated;
        public IValidation<Pi> AddValidation(IValidation<Pi> validation)
        {
            if (_validations == null) _validations = new List<IValidation<Pi>>();
            _validations = _validations.Append(validation);
            return this;
        }

        public IValidation<Pi> RemoveValidation(IValidation<object> validation)
        {
            _validations = _validations.Where(x => !x.Equals(validation));
            return this;
        }


        public IEnumerable<IValidationError> GetWarnings()
        {
            throw new NotImplementedException();
        }

        public bool IsValidated() => _isValidated;

        public bool Validate(Pi e)
        {
            int errors = 0;
            foreach (var validation in _validations)
            {
                if(!validation.Validate(e)) errors ++;
            }
            _isValidated = errors == 0;
            return _isValidated;
        }

        public IEnumerable<IValidationError> GetValidationErrors()
        {
            foreach (var validation in _validations) {
                if (!validation.IsValidated()) yield return validation.GetValidationError();
            }
        }

        public IValidationError GetValidationError()
        {
            return new ValidationError("Pi Validation Failure", "Check Validation errors");
        }
    }

    public class ValidationError : IValidationError
    {
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }

        public ValidationResult Result { get; private set; }

        public ValidationError(string description, string message)
        {
            Description = description;
            ErrorMessage = message;
            Result = ValidationResult.NotValidated;
        }
        public override string ToString()
        {
            return $"\n{Description}: {ErrorMessage}";
        }

        public void SetResult(ValidationResult result) => Result = result;
    }
}
