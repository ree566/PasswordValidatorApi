using PasswordValidatorApi.Models;
using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.IntegrationTests
{
    public class ValidatorRuleServiceTest
    {
        [Fact]
        public void AddRules_HasOneAddedRule()
        {
            IPasswordRule rule = new CharacterLengthFilterRule();
            List<IPasswordRule> rules = new List<IPasswordRule>();

            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl(rules);

            ruleService.AddRules(rule);

            Assert.True(rules.Count > 0);

            Assert.Contains<IPasswordRule>(rule, rules);
        }

        [Fact]
        public void RemoveRules_HasEmptyRule()
        {
            IPasswordRule rule = new CharacterLengthFilterRule();
            List<IPasswordRule> rules = new List<IPasswordRule>() {
                rule
            };

            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl(rules);

            ruleService.RemoveRules(rule);

            Assert.True(rules.Count == 0);
        }

        [Fact]
        public void GetRules_HasOneAddedRule()
        {
            IPasswordRule rule = new CharacterLengthFilterRule();
            List<IPasswordRule> rules = new List<IPasswordRule>() {
                rule
            };

            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl(rules);

            List<IPasswordRule> result = ruleService.GetRules();

            Assert.True(result.Count > 0);

            Assert.Contains<IPasswordRule>(rule, result);
        }
    }
}
