using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class LowerCaseAndDigitsOnlyValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Lowercase character and digits only";
        private readonly Regex regex = new Regex("[^a-z^\\d]+");

        /// <summary>
        /// Returns error when text contains non lowercase and digit character
        /// </summary>
        /// <param name="item">validated text</param>
        /// <returns></returns>
        /// <exception cref="ChainHandlerException"></exception>
        public HandlerResult ProcessRequest(string item)
        {
            Match match = regex.Match(item);

            if (match.Success)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
