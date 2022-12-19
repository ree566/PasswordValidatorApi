using PasswordValidatorApi.Models.ValidatorRules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class NotContainAdjacentSameSequenceRuleTest
    {
        [Theory]
        [InlineData("abc123abc")]
        [InlineData("123abcdef")]
        [InlineData("ABC1ABC")]
        [InlineData("ABC_ABC")]
        [InlineData("ABd1ABC")]
        [InlineData("ab3abc")]
        [InlineData("ABC")]
        [InlineData("abc")]
        public void Validate_FilterRules_ReturnsTrue(string value)
        {
            IPasswordRule rule = new NotContainAdjacentSameSequenceRule();

            var result = rule.Validate(value);

            Assert.True(!result.HasErrors());
        }

        [Theory]
        [InlineData("AA")]
        [InlineData("AAB")]
        [InlineData("aa")]
        [InlineData("aab")]
        [InlineData("11")]
        [InlineData("11a")]
        [InlineData("abcabc")]
        [InlineData("123123")]
        [InlineData("abcdabcd")]
        [InlineData("abbaabba")]
        [InlineData("abc_abc_")]
        [InlineData("#!@#!@")]
        public void Validate_NotFilterRules_ReturnsFalse(string value)
        {
            IPasswordRule rule = new NotContainAdjacentSameSequenceRule();

            var result = rule.Validate(value);

            Assert.True(result.HasErrors());
        }
    }
}
