using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class ContainsAtLeastOneDigitsValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Lowercase character and digits only";
        private readonly Regex regex = new Regex("[\\d]+");

        public HandlerResult ProcessRequest(string item)
        {
            Match match = regex.Match(item);

            if (!match.Success)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
