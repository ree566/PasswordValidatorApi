using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class ContainsAtLeastOneUppercaseRuleTest
    {
        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        public void Validate_FilterRules_ReturnsTrue(string value)
        {
            IPasswordRule rule = new ContainsAtLeastOneUppercaseRule();

            var result = rule.Validate(value);

            Assert.True(!result.HasErrors());
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void Validate_NotFilterRules_ReturnsFalse(string value)
        {
            IPasswordRule rule = new ContainsAtLeastOneUppercaseRule();

            var result = rule.Validate(value);

            Assert.True(result.HasErrors());
        }
    }
}
