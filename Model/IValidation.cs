using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{

    public interface IValidationFactory<Entity> {
        public IValidation<Entity> Create();
        public IValidationCheck<Entity> CreateValidationCheck();
        public IValidationFactory<Entity> Dispose();
    }
    public interface IValidation<Entity>
    {
        public bool Validate(Entity e);
        public bool IsValidated();
        public IEnumerable<IValidationError> GetValidationErrors();
        public IEnumerable<IValidationError> GetWarnings();
        public IEnumerable<IValidationCheck<Entity>> GetValidationChecks();
        public void AddValidationCheck(IValidationCheck<Entity> validationCheck);
        public void AddValidationCheck(IValidationCondition<Entity> condition, IValidationError error);
        public void RemoveValidationCheck(IValidationCheck<Entity> validationCheck);


    }
    public interface IValidationWarning {
        public bool GetWarningMessage();
    }
    public interface IValidationError {
        public string GetErrorMessage();
        
    }
    public interface IValidationCheck<Entity> {
        public void SetCondition(IValidationCondition<Entity> condition);
        public void SetError(IValidationError error);
        public IValidationError Error { get; }
        public bool Validate(Entity e);
        public bool IsValidated();
        
    }
    public interface IValidationCondition<Entity> {
        Func<Entity, object[]?, bool> ConditionCheck { get; set; }
        public bool Verify(Entity e, [Optional] object[]? parameters);
        public bool IsVerified();
      
    }

    public enum ValidationCheckStatus { 
        Validated = 0,
        NotValidated = 2,
        ValidatedWithError = 3,
        ValidatedWithWarning = 4,
        
    }
}
