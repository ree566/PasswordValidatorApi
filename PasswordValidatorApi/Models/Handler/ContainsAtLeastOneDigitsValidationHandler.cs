using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class ContainsAtLeastOneDigitsValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Must have at least one digits!";
        private readonly Regex regex = new Regex("[\\d]+");

        /// <summary>
        /// Return error when text doesn't have digit in it
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
