using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class ContainsAtLeastOneLowerCaseValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Must contains at least one lowercase character!";
        private readonly Regex regex = new Regex("[a-z]+");

        /// <summary>
        /// Returns error when text doesn't have lowercase in it
        /// </summary>
        /// <param name="item">validated text</param>
        /// <returns></returns>
        /// <exception cref="ChainHandlerException"></exception>
        public HandlerResult ProcessRequest(string item)
        {
            Match match = regex.Match(item);

            if (!match.Success)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
