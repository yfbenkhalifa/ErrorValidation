
using ErrorValidation.Model;

namespace ErrorValidation.UnitTest
{
    public class Pi
    {
        public int value { get; set; }
    }

    public class ErrorValidationTest
    {

        public class PiValueValidation : IValidation<Pi>
        {
            private bool _isValidated;
            public IValidationError GetValidationError()
            {
                return new ValidationError("Value Error", "Valore non valido");
            }

            public IEnumerable<IValidationError> GetValidationErrors()
            {
                return new List<IValidationError>() { GetValidationError() };
            }

            public IEnumerable<IValidationError> GetWarnings()
            {
                throw new NotImplementedException();
            }

            public bool IsValidated() => _isValidated;

            public bool Validate(Pi p)
            {
                _isValidated = Math.Abs(p.value) == 2;
                return _isValidated;
            }
        }
        public class PiDoubleValidation : IValidation<Pi>
        {
            private bool _isValidated;

            public IValidationError GetValidationError()
            {
                return new ValidationError("Type Error", "Tipo variabile non valido");
            }

            public IEnumerable<IValidationError> GetValidationErrors()
            {
                return new List<IValidationError> { GetValidationError()};
            }

            public IEnumerable<IValidationError> GetWarnings()
            {
                throw new NotImplementedException();
            }

            public bool IsValidated() => _isValidated;

            public bool Validate(Pi e)
            {
                _isValidated = e.value > 0;
                return _isValidated;
            }
        }
        static void Main(string[] args)
        {
            Pi pi = new Pi { value = 2 };
            
            PiValidation validation = new PiValidation();
            validation.AddValidation(new PiValueValidation());
            validation.AddValidation(new PiDoubleValidation());
            bool ok = validation.Validate(pi);
            if (!ok)
            {
                foreach (var error in validation.GetValidationErrors())
                {
                    Console.WriteLine($"\n{error.Description} : {error.ErrorMessage}");
                }
            }
            else {
                Console.WriteLine("OK");
            }

        }

        

    }
}