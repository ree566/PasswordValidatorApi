using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class ContainsAtLeastOneUppercaseValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Lowercase character and digits only";
        private readonly Regex regex = new Regex("[A-Z]+");

        public HandlerResult ProcessRequest(string item)
        {
            Match match = regex.Match(item);

            if (!match.Success)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
