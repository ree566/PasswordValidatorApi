using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class ContainsAtLeastOneDigitsValidationHandlerTest
    {
        [Theory]
        [InlineData("1234567890")]
        public void ProcessRequest_FilterRules_ReturnsTrue(string value)
        {
            IChainHandler<string> handler = new ContainsAtLeastOneDigitsValidationHandler();

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void ProcessRequest_NotFilterRules_ThrowError(string value)
        {
            IChainHandler<string> rule = new ContainsAtLeastOneDigitsValidationHandler();

            Assert.Throws<ChainHandlerException>(() => rule.ProcessRequest(value));
        }
    }
}
