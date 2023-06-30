
using ErrorValidation.Model;
using System.Reflection.Metadata.Ecma335;

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
            Pi pi = new Pi { value = 3.1 };

            //// Declare validation
            //Validation<Pi> PiValidation = new Validation<Pi>();
            //// Create checks to validate
            //ValidationCondition<Pi> piIsCorrect = new ValidationCondition<Pi>( (p, paramters) => { return Double.TryParse(p.value.ToString(), out _); });
            //ValidationError validationError = new ValidationError("PI Error Value", "Valore del pi greco non valido");

            //var piIsDouble = new ValidationCondition<Pi>( (p, parameters) => { return p.value == 3.14; });
            //var piIsDoubleError = new ValidationError("Pi Invalid Format", "Tipologia pi graco non valida");

            //ValidationCheck<Pi> valueCheck = new ValidationCheck<Pi>(piIsCorrect, validationError);
            //var typeCheck = new ValidationCheck<Pi>(piIsDouble, piIsDoubleError);

            //// Add check to Validation
            //PiValidation.AddValidationCheck(valueCheck);
            //PiValidation.AddValidationCheck(typeCheck);

            // Validation factory
            ValidationFactory<Pi> validationFactory = new ValidationFactory<Pi>();
            var validation = validationFactory.Create();
            validation.AddValidationCheck(
                    new ValidationCondition<Pi>((p, parameters) => { return p.value == 3.14; }), new ValidationError("Pi Invalid Format", "Tipologia pi graco non valida"));


            // Perform validation
            Console.WriteLine("Validation Result : " + validation.Validate(pi));
            var errors = validation.GetValidationErrors();
            foreach (var error in errors) {
                Console.WriteLine(error.ToString());
            }
        }

        

    }
}