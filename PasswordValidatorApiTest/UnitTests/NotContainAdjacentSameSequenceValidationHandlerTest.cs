using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class NotContainAdjacentSameSequenceValidationHandlerTest
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
            IChainHandler<string> handler = new NotContainAdjacentSameSequenceValidationHandler();

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
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
        public void Validate_NotFilterRules_ThrowError(string value)
        {
            IChainHandler<string> handler = new NotContainAdjacentSameSequenceValidationHandler();

            Assert.Throws<ChainHandlerException>(() => handler.ProcessRequest(value));
        }
    }
}
