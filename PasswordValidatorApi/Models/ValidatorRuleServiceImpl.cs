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

        public ValidatorRuleServiceImpl(List<IPasswordRule> rules)
        {
            Rules = rules;
        }

        public void AddRules(IPasswordRule rules)
        {
            AddRules(rules);
        }

        public void AddRules(params IPasswordRule[] rules)
        {
            Rules.AddRange(rules);
        }

        public List<IPasswordRule> GetRules()
        {
            return Rules;
        }

        public void RemoveRules(IPasswordRule rules)
        {
            RemoveRules(rules);
        }

        public void RemoveRules(params IPasswordRule[] rules)
        {
            foreach(IPasswordRule rule in rules)
            {
                Rules.Remove(rule);
            }
        }
    }
}
