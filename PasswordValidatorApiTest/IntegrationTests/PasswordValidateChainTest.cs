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
using PasswordValidatorApi.Models.ChainManagement;
using PasswordValidatorApi.Models.Handler;
using PasswordValidatorApi.Models.HandlerChain;
using Xunit;

namespace PasswordValidatorApiTest.IntegrationTests
{
    public class PasswordValidateChainTest
    {

        [Theory]
        [InlineData(1, 10, "abc123")]
        [InlineData(2, 20, "123abc")]
        [InlineData(3, int.MaxValue, "a1b2c3d4")]
        public void ProcessRequest_HasValidPasswordForAllRule_ReturnNoException(int min, int max, string item)
        {
            ChainManager<string> passwordValidateChain = new ChainManager<string>() { StopOnFirstException = false };
            passwordValidateChain.AppendHandlerToChain(new IChainHandler<string>[]
            {
                new CharacterLengthFilterValidationHandler(min, max),
                new ContainsAtLeastOneDigitsValidationHandler(),
                new ContainsAtLeastOneLowerCaseValidationHandler(),
                new LowerCaseAndDigitsOnlyValidationHandler(),
                new NotContainsAdjacentSameSequenceValidationHandler()
            });

            List<ChainHandlerException> exceptions;
            var result = passwordValidateChain.ProcessRequest(item, out exceptions);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
            Assert.Empty(exceptions);
        }

        [Theory]
        [InlineData(1, 10, "abcA123A")]
        [InlineData(2, 20, "123abcABC")]
        [InlineData(3, int.MaxValue, "a1b2c3d4e5")]
        [InlineData(1, 10, "abc!A123A")]
        [InlineData(2, 20, "123a_bcABC")]
        public void ProcessRequest_HasValidPasswordWithoutLowercaseDigitOnlyValidateChain_ReturnNoException(int min, int max, string item)
        {
            ChainManager<string> passwordValidateChain = new ChainManager<string>() { StopOnFirstException = false };
            passwordValidateChain.AppendHandlerToChain(new IChainHandler<string>[]
            {
                new CharacterLengthFilterValidationHandler(min, max),
                new ContainsAtLeastOneDigitsValidationHandler(),
                new ContainsAtLeastOneLowerCaseValidationHandler(),
                new NotContainsAdjacentSameSequenceValidationHandler()
            });

            List<ChainHandlerException> exceptions;
            var result = passwordValidateChain.ProcessRequest(item, out exceptions);

            Assert.True(result == HandlerResult.CHAIN_DATA_HANDLED);
            Assert.Empty(exceptions);
        }

        [Theory]
        [InlineData(0, 0, "")]
        [InlineData(0, 10, "_#$@")]
        [InlineData(0, 10, "ABCDEF")]
        [InlineData(0, 10, "ABC$#%#DEF")]
        public void ProcessRequest_HasInValidPasswordWithoutLowercaseDigitOnlyValidateChain_ReturnException(int min, int max, string item)
        {
            ChainManager<string> passwordValidateChain = new ChainManager<string>() { StopOnFirstException = false };
            passwordValidateChain.AppendHandlerToChain(new IChainHandler<string>[]
            {
                new CharacterLengthFilterValidationHandler(min, max),
                new ContainsAtLeastOneDigitsValidationHandler(),
                new ContainsAtLeastOneLowerCaseValidationHandler(),
                new NotContainsAdjacentSameSequenceValidationHandler()
            });

            List<ChainHandlerException> exceptions;
            var result = passwordValidateChain.ProcessRequest(item, out exceptions);

            Assert.True(result == HandlerResult.CHAIN_DATA_NOT_HANDLED);
            Assert.NotEmpty(exceptions);
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
        [InlineData(0, 0, "")]
        [InlineData(int.MinValue, int.MinValue, "a1")]
        public void ProcessRequest_HasInValidPasswordForAllRule_ReturnException(int min, int max, string item)
        {
            ChainManager<string> passwordValidateChain = new ChainManager<string>() { StopOnFirstException = false };
            passwordValidateChain.AppendHandlerToChain(new IChainHandler<string>[]
            {
                new CharacterLengthFilterValidationHandler(min, max),
                new ContainsAtLeastOneDigitsValidationHandler(),
                new ContainsAtLeastOneLowerCaseValidationHandler(),
                new LowerCaseAndDigitsOnlyValidationHandler(),
                new NotContainsAdjacentSameSequenceValidationHandler()
            });

            List<ChainHandlerException> exceptions;
            var result = passwordValidateChain.ProcessRequest(item, out exceptions);

            Assert.True(result == HandlerResult.CHAIN_DATA_NOT_HANDLED);
            Assert.NotEmpty(exceptions);

        }
    }
}