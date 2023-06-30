
using ErrorValidation.Model;

namespace ErrorValidation.UnitTest
{
    public class Pi
    {
        public int value { get; set; }
    }

    public class ErrorValidationTest
    {
        
        public class PiValueValidation : IValidation<Pi> {
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

            public bool Validate(Pi p) => Math.Abs(p.value) == 3;
        }
        public class PiDoubleValidation : IValidation<Pi>
        {
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

            public bool Validate(Pi e) => e.value > 0;
        }
        static void Main(string[] args)
        {
            Pi pi = new Pi { value = -3 };
            
            PiValidation validation = new PiValidation();
            validation.AddValidation(new PiValueValidation());
            validation.AddValidation(new PiDoubleValidation());
            Console.WriteLine(validation.Validate(pi));

        }

        

    }
}