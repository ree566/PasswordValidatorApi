using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class CharacterLengthFilterValidationHandlerTest
    {
        [Theory]
        [InlineData(1, 9, "abc123abc")]
        [InlineData(1, 6, "abcdef")]
        [InlineData(int.MinValue, int.MaxValue, "abcdef")]
        public void ProcessRequest_FilterRules_ReturnsTrue(int min, int max, string value)
        {
            IChainHandler handler = new CharacterLengthFilterValidationHandler(min, max);

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
        }

        [Theory]
        [InlineData(1, 2, "ABCABC")]
        [InlineData(int.MaxValue, int.MaxValue, "ABC123")]
        public void ProcessRequest_NotFilterRules_ThrowError(int min, int max, string value)
        {
            IChainHandler handler = new CharacterLengthFilterValidationHandler(min, max);

            Assert.Throws<ChainHandlerException>(() => handler.ProcessRequest(value));
        }

    }
}
