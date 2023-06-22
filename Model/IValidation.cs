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
        public IEnumerable<ValidationError> GetValidationErrors();
        public IEnumerable<ValidationError> GetWarnings();
        public IEnumerable<IValidationCheck<Entity>> GetValidationChecks();
        

    }
    public interface IValidationWarning {
        public bool GetWarningMessage();
    }
    public interface IValidationError {
        public string GetErrorMessage();
        
    }
    public interface IValidationCheck<Entity> { 
        public bool Validate(Entity e);
        public bool IsValidated();
        public IEnumerable<ValidationError> GetValidationErrors();
    }
    public interface IValidationCondition<Entity> {
        Func<Entity, bool> ConditionCheck { get; set; }

        public bool Verify(Entity e);
        public bool IsVerified();
    }
}
