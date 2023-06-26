
using ErrorValidation.Model;

namespace ErrorValidation.UnitTest
{
    public class Pi
    {
        public double value { get; set; }
    }

    public class ErrorValidationTest
    {
        public static bool IsCorrect(Pi p) => p.value == 3.14;
        public static bool IsDouble(Pi p) => Double.TryParse(p.value.ToString(), out _);
        static void Main(string[] args)
        {
            Pi pi = new Pi { value = 1 };

            // Decalre validation
            Validation<Pi> PiValidation = new Validation<Pi>();
            // Create checks to validate
            ValidationCondition<Pi> piIsCorrect = new ValidationCondition<Pi>(IsCorrect);
            ValidationError validationError = new ValidationError("PI Error Value", "Valore del pi greco non valido");

            var piIsDouble = new ValidationCondition<Pi>(IsDouble);
            var piIsDoubleError = new ValidationError("Pi Invalid Format", "Tipologia pi graco non valida");

            ValidationCheck<Pi> valueCheck = new ValidationCheck<Pi>(piIsCorrect, validationError);
            var typeCheck = new ValidationCheck<Pi>(piIsDouble, piIsDoubleError);

            // Add check to Validation
            PiValidation.AddValidationCheck(valueCheck);
            PiValidation.AddValidationCheck(typeCheck);

            // Perform validation
            Console.WriteLine("Validation Result : " + PiValidation.Validate(pi));
            var errors = PiValidation.GetValidationErrors();
            foreach (var error in errors) {
                Console.WriteLine(error.ToString());
            }
        }

        

    }
}