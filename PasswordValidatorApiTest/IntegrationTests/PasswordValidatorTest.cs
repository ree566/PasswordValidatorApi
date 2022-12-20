using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using PasswordValidatorApi;
using PasswordValidatorApi.Models;
using PasswordValidatorApi.Models.ValidatorRules;
using Xunit;

namespace PasswordValidatorApiTest.IntegrationTests
{
    public class PasswordValidatorTest : IClassFixture<WebApplicationFactory<Startup>>
    {

        [Theory]
        [InlineData(1, 10, "abc123")]
        [InlineData(2, 20, "123abc")]
        [InlineData(3, int.MaxValue, "a1b2c3d4")]
        public void PasswordValidator_HasValidPasswordForAllRule_ReturnsTrue(int min, int max, string item)
        {
            PasswordValidator validator = new PasswordValidator(
                new ValidatorRuleServiceImpl()
                {
                    Rules = {
                        new CharacterLengthFilterRule(min, max),
                        new ContainsAtLeastOneLowerCaseRule(),
                        new ContainsAtLeastOneDigitsRule(),
                        new LowerCaseAndDigitsOnlyRule(),
                        new NotContainAdjacentSameSequenceRule()
                    }
                }
            );

            var result = validator.ValidateRules(item);

            Assert.True(result.IsValid);
        }

        [Theory]
        [InlineData(1, 10, "123456789")]
        [InlineData(2, 20, "abcdefghi")]
        [InlineData(1, 10, "a1b2c3d4e5f")]
        [InlineData(1, 10, "a-1b2c3d4")]
        [InlineData(1, 10, "a1b2c$%3d4")]
        [InlineData(1, 10, "a1B2c3d4")]
        [InlineData(1, 10, "ab12-ab12-")]
        [InlineData(1, 10, "aa1")]
        [InlineData(1, 10, "a1a1")]
        [InlineData(1, 10, "")]
        [InlineData(int.MinValue, int.MinValue, "a1")]
        public void PasswordValidator_HasInValidPasswordForAllRule_ReturnsFalse(int min, int max, string item)
        {
            PasswordValidator validator = new PasswordValidator(
                new ValidatorRuleServiceImpl()
                {
                    Rules = {
                        new CharacterLengthFilterRule(min, max),
                        new ContainsAtLeastOneLowerCaseRule(),
                        new ContainsAtLeastOneDigitsRule(),
                        new LowerCaseAndDigitsOnlyRule(),
                        new NotContainAdjacentSameSequenceRule()
                    }
                }
            );

            var result = validator.ValidateRules(item);

            Assert.False(result.IsValid);

        }
    }
}