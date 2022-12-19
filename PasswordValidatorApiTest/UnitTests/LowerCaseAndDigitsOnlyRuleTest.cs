using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class LoweraseRuleTest
    {
        [Theory]
        [InlineData("abc123abc")]
        [InlineData("123abcdef")]
        [InlineData("abcdef123")]
        public void Validate_FilterRules_ReturnsTrue(string value)
        {
            IPasswordRule rule = new LowerCaseAndDigitsOnlyRule();

            var result = rule.Validate(value);

            Assert.True(!result.HasErrors());
        }

        [Theory]
        [InlineData("ABCABC")]
        [InlineData("ABCabc")]
        [InlineData("ABC123")]
        [InlineData("ABC123abc")]
        [InlineData("ABC-123-abc")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void Validate_NotFilterRules_ReturnsFalse(string value)
        {
            IPasswordRule rule = new LowerCaseAndDigitsOnlyRule();

            var result = rule.Validate(value);

            Assert.True(result.HasErrors());
        }
    }
}
