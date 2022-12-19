using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PasswordValidatorApi.Models
{
    public class ValidatorRuleServiceImpl : IValidatorRuleService
    {

        public List<IPasswordRule> Rules { get; set; }

        public ValidatorRuleServiceImpl()
        {
            Rules = new List<IPasswordRule>();
        }

        public List<IPasswordRule> AddRules(IPasswordRule rules)
        {
            AddRules(rules);
            return Rules;
        }

        public List<IPasswordRule> AddRules(params IPasswordRule[] rules)
        {
            Rules.AddRange(rules);
            return Rules;
        }

        public List<IPasswordRule> GetRules()
        {
            return Rules;
        }

        public List<IPasswordRule> RemoveRules(IPasswordRule rules)
        {
            RemoveRules(rules);
            return Rules;
        }

        public List<IPasswordRule> RemoveRules(params IPasswordRule[] rules)
        {
            foreach(IPasswordRule rule in rules)
            {
                Rules.Remove(rule);
            }
            return Rules;
        }
    }
}
