using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class ContainsAtLeastOneUppercaseValidationHandlerTest
    {
        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        public void ProcessRequest_FilterRules_ReturnsTrue(string value)
        {
            IChainHandler<string> handler = new ContainsAtLeastOneUppercaseValidationHandler();

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
        }

        [Theory]
        [InlineData("1234567890")]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void ProcessRequest_NotFilterRules_ThrowError(string value)
        {
            IChainHandler<string> handler = new ContainsAtLeastOneUppercaseValidationHandler();

            Assert.Throws<ChainHandlerException>(() => handler.ProcessRequest(value));
        }
    }
}
