using System;

namespace PasswordValidatorApi.Models.HandlerChain
{
    public class ChainHandlerException : Exception
    {
        public ChainHandlerException(string msg)
            : base(msg)
        {
        }
    }
}
