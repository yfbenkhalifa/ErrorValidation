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

        public IEnumerable<IValidationError> GetValidationErrors()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IValidationError> GetWarnings()
        {
            throw new NotImplementedException();
        }

        public bool IsValidated()
        {
            throw new NotImplementedException();
        }

       

        public bool Validate(Pi e)
        {
            _isValidated = true;
            foreach (var validation in _validations)
            {
                _isValidated = validation.Validate(e);
            }
            return _isValidated;
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
