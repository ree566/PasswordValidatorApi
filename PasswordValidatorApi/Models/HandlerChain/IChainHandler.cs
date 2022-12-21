namespace PasswordValidatorApi.Models.HandlerChain
{
    public interface IChainHandler<REQUEST_TYPE>
    {
        public HandlerResult ProcessRequest(REQUEST_TYPE item);

    }
}
