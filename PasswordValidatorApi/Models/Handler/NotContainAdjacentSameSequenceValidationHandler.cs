using PasswordValidatorApi.Models.HandlerChain;
using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models.Handler
{
    public class NotContainAdjacentSameSequenceValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Adjacent same sequence not allowed";
        private readonly Regex regex = new Regex("(.+)\\1");

        public HandlerResult ProcessRequest(string item)
        {
            Match match = regex.Match(item);

            if (match.Success)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
