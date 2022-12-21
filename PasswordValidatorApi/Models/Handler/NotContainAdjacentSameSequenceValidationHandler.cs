using PasswordValidatorApi.Models.HandlerChain;
using System.Text.RegularExpressions;

namespace PasswordValidatorApi.Models.Handler
{
    public class NotContainAdjacentSameSequenceValidationHandler : IChainHandler<string>
    {
        private readonly string error_message = "Adjacent same sequence not allowed";
        private readonly Regex regex = new Regex("(.+)\\1");

        /// <summary>
        /// Returns error when same sequence strings are adjacent
        /// </summary>
        /// <param name="item">validated text</param>
        /// <returns></returns>
        /// <example>
        /// There shows the invalid example
        /// <code>aa, aaaa, abab, ab12ab12, ABcABc</code>
        /// </example>
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
