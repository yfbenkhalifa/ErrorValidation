using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{

    public interface IValidation<Entity>
    {
        /// <summary>
        /// Performs the validation.
        /// </summary>
        /// <param name="e">Object to Validate</param>
        /// <returns>Return true if no errors are found, false otherwise</returns>
        public bool Validate(Entity e);
        /// <summary>
        /// Check whether or not the validation went though without errors. It is advised to implement
        /// a private property that keeps track of the validation during the Validate method.
        /// </summary>
        /// <returns>True is the validation succeded, false otehrwise.</returns>
        public bool IsValidated();
        /// <summary>
        /// This method return all the validation errors linked to the current validation,
        /// remember to use IsValidated() method to select only the failed validations. This method is used 
        /// in the case the current validation acts as a root for a cascade of other validations. 
        /// </summary>
        /// <returns>IEnumerable of IValidationError</returns>        
        public IEnumerable<IValidationError> GetValidationErrors();
        /// <summary>
        /// This return the single error of the current Validation.
        /// </summary>
        /// <returns></returns>
        public IValidationError GetValidationError();
        
        public IEnumerable<IValidationError> GetWarnings();
    }
    public interface IValidationWarning {
        public bool GetWarningMessage();
    }

    public interface IValidationError {
        
        
        public string Description { get; set; }
        public string ErrorMessage { get; set; }
        public string WarningMessage { get; set; }
        
    }
    public interface IValidationCheck<Entity> {
        IValidationError Error { get; set; }
        public bool Validate(Entity e);
        public bool IsValidated();
        
    }
    public interface IValidationCondition<Entity> {
        Func<Entity, bool> ConditionCheck { get; set; }
        public bool Verify(Entity e);
        public bool IsVerified();
      
    }

    public enum ValidationResult { Success, Failure, Warning, Error, NotValidated}


}
