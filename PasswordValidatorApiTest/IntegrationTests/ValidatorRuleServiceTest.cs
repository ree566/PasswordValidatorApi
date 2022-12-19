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
            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl();

            IPasswordRule rule = new CharacterLengthFilterRule();

            List<IPasswordRule> result = ruleService.AddRules(rule);

            Assert.True(result.Count > 0);

            Assert.Contains<IPasswordRule>(rule, result);
        }

        [Fact]
        public void RemoveRules_HasEmptyRule()
        {
            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl();

            IPasswordRule rule = new CharacterLengthFilterRule();
            ruleService.AddRules(rule);
            var result = ruleService.RemoveRules(rule);

            Assert.True(result.Count == 0);
        }

        [Fact]
        public void GetRules_HasOneAddedRule()
        {
            IValidatorRuleService ruleService = new ValidatorRuleServiceImpl();

            IPasswordRule rule = new CharacterLengthFilterRule();
            ruleService.AddRules(rule);
            List<IPasswordRule> result = ruleService.GetRules();

            Assert.True(result.Count > 0);

            Assert.Contains<IPasswordRule>(rule, result);
        }
    }
}
