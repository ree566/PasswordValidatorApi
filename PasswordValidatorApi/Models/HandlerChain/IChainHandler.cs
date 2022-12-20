namespace PasswordValidatorApi.Models.HandlerChain
{
    public interface IChainHandler
    {
        public HandlerResult ProcessRequest(string item);

    }
}
