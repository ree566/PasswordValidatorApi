using System.Data;
using System.Text.RegularExpressions;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Models.Handler
{
    public class CharacterLengthFilterValidationHandler : IChainHandler<string>
    {

        private readonly string error_message = "Character length is invalid!";

        public int LenMin { get; set; } = 1;

        public int LenMax { get; set; } = int.MaxValue;

        public CharacterLengthFilterValidationHandler()
        {

        }

        public CharacterLengthFilterValidationHandler(int min, int max)
        {
            LenMin = min;
            LenMax = max;
        }

        /// <summary>
        /// Throw error when text is null or empty or size not between the <paramref name="min"/> and <paramref name="max"/> 
        /// </summary>
        /// <param name="item">validated text</param>
        /// <returns></returns>
        /// <exception cref="ChainHandlerException"></exception>
        public HandlerResult ProcessRequest(string item)
        {
            if (string.IsNullOrEmpty(item) || item.Length < LenMin || item.Length > LenMax)
                throw new ChainHandlerException(error_message);

            return HandlerResult.CHAIN_DATA_HANDLED;
        }
    }
}
