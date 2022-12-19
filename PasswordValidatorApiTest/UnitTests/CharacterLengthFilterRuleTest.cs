using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class CharacterLengthFilterRuleTest
    {
        [Theory]
        [InlineData(1, 9, "abc123abc")]
        [InlineData(1, 6, "abcdef")]
        [InlineData(int.MinValue, int.MaxValue, "abcdef")]
        public void Validate_FilterRules_ReturnsTrue(int min, int max, string value)
        {
            IPasswordRule rule = new CharacterLengthFilterRule(min, max);

            var result = rule.Validate(value);

            Assert.True(!result.HasErrors());
        }

        [Theory]
        [InlineData(1, 2, "ABCABC")]
        [InlineData(int.MaxValue, int.MaxValue, "ABC123")]
        public void Validate_NotFilterRules_ReturnsFalse(int min, int max, string value)
        {
            IPasswordRule rule = new CharacterLengthFilterRule(min, max);

            var result = rule.Validate(value);

            Assert.True(result.HasErrors());
        }

    }
}
