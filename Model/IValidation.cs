using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErrorValidation.Model
{
    public interface IValidation
    {
        public bool Validate();
        public bool IsValidated();
        public IEnumerable<ValidationError> GetValidationErrors();
        public IEnumerable<ValidationError> GetWarnings();
        public IEnumerable<IValidationCheck> GetValidationChecks();
        

    }
    public interface IValidationCheck { 
        public bool Validate();
        public bool IsValidated();
        public IEnumerable<ValidationError> GetValidationErrors();
    }
    public interface IValidationCondition<Entity> {
        Func<Entity, bool> ConditionCheck { get; set; }

        public bool Verify(Entity e);
        public bool IsVerified();
    }
}
