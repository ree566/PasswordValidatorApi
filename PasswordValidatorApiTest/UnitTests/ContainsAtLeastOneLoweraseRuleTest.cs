using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class ContainsAtLeastOneLoweraseRuleTest
    {
        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        public void Validate_FilterRules_ReturnsTrue(string value)
        {
            IPasswordRule rule = new ContainsAtLeastOneLowerCaseRule();

            var result = rule.Validate(value);

            Assert.True(!result.HasErrors());
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("1234567890")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void Validate_NotFilterRules_ReturnsFalse(string value)
        {
            IPasswordRule rule = new ContainsAtLeastOneLowerCaseRule();

            var result = rule.Validate(value);

            Assert.True(result.HasErrors());
        }
    }
}
