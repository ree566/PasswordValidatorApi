using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class LowerCaseAndDigitsOnlyValidationHandlerTest
    {
        [Theory]
        [InlineData("abc123abc")]
        [InlineData("123abcdef")]
        [InlineData("abcdef123")]
        public void ProcessRequest_FilterRules_ReturnsTrue(string value)
        {
            IChainHandler handler = new LowerCaseAndDigitsOnlyValidationHandler();

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
        }

        [Theory]
        [InlineData("ABCABC")]
        [InlineData("ABCabc")]
        [InlineData("ABC123")]
        [InlineData("ABC123abc")]
        [InlineData("ABC-123-abc")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void ProcessRequest_NotFilterRules_ThrowError(string value)
        {
            IChainHandler handler = new LowerCaseAndDigitsOnlyValidationHandler();

            Assert.Throws<ChainHandlerException>(() => handler.ProcessRequest(value));
        }
    }
}
