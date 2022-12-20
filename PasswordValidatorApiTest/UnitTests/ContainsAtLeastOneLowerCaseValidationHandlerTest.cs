using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PasswordValidatorApiTest.UnitTests
{
    public class ContainsAtLeastOneLowerCaseValidationHandlerTest
    {
        [Theory]
        [InlineData("abcdefghijklmnopqrstuvwxyz")]
        public void ProcessRequest_FilterRules_ReturnsTrue(string value)
        {
            IChainHandler handler = new ContainsAtLeastOneLowerCaseValidationHandler();

            var result = handler.ProcessRequest(value);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
        }

        [Theory]
        [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ")]
        [InlineData("1234567890")]
        [InlineData("!@#$%^^&*()_+|~}{\":?><")]
        public void ProcessRequest_NotFilterRules_ThrowError(string value)
        {
            IChainHandler handler = new ContainsAtLeastOneLowerCaseValidationHandler();

            Assert.Throws<ChainHandlerException>(() => handler.ProcessRequest(value));
        }
    }
}
