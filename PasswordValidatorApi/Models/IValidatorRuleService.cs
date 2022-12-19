using PasswordValidatorApi.Models.ValidatorRules;
using System.Collections.Generic;

namespace PasswordValidatorApi.Models
{
    public interface IValidatorRuleService
    {
        public List<IPasswordRule> GetRules();

        public List<IPasswordRule> AddRules(params IPasswordRule[] rules);

        public List<IPasswordRule> RemoveRules(params IPasswordRule[] rules);
    }
}
