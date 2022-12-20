using PasswordValidatorApi.Models.ValidatorRules;
using System.Collections.Generic;

namespace PasswordValidatorApi.Models
{
    public interface IValidatorRuleService
    {
        public List<IPasswordRule> GetRules();

        public void AddRules(params IPasswordRule[] rules);

        public void RemoveRules(params IPasswordRule[] rules);
    }
}
