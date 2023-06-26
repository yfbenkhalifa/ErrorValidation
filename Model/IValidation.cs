using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public interface IValidation<Entity>
    {
        public bool Validate(Entity e);
        public bool IsValidated();
        public IEnumerable<IValidationError> GetValidationErrors();
        public IEnumerable<IValidationError> GetWarnings();
        public IEnumerable<IValidationCheck<Entity>> GetValidationChecks();
        public void AddValidationCheck(IValidationCheck<Entity> validationCheck);
        public void RemoveValidationCheck(IValidationCheck<Entity> validationCheck);


    }
    public interface IValidationWarning {
        public bool GetWarningMessage();
    }
    public interface IValidationError {
        public string GetErrorMessage();
        
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
}
