using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models
{
    public class PasswordValidator : IPasswordValidator
    {
        private IValidatorRuleService _ruleService;

        public PasswordValidator(IValidatorRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        public ValidationResult ValidateRules(string item)
        {
            List<IPasswordRule> rules = _ruleService.GetRules();

            if (rules.Count == 0)
            {
                return new ValidationResult() { IsValid = true };
            }

            List<string> errorMessages = new List<string>();

            foreach (IPasswordRule rule in rules)
            {
                ValidationErrors errors = rule.Validate(item);
                if (errors.HasErrors())
                {
                    errorMessages.AddRange(errors.GetErrorMessages());
                }
            }

            if (errorMessages.Count > 0)
            {
                return new ValidationResult()
                {
                    IsValid = false,
                    Messages = errorMessages
                };
            }

            return new ValidationResult() { IsValid = true };
        }
    }
}
