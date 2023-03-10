using PasswordValidatorApi.Models.HandlerChain;
using System.Collections.Generic;

namespace PasswordValidatorApi.Models.ChainManagement
{
    public class ChainManager<REQUEST_TYPE>
    {
        private List<IChainHandler<REQUEST_TYPE>> handlerChain = new List<IChainHandler<REQUEST_TYPE>>();

        public bool StopOnFirstException { get; set; } = false;

        public ChainManager()
        {

        }

        public ChainManager<REQUEST_TYPE> AppendHandlerToChain(params IChainHandler<REQUEST_TYPE>[] handlers)
        {
            foreach (IChainHandler<REQUEST_TYPE> handler in handlers)
            {
                AppendHandlerToChain(handler);
            }
            return this;
        }

        public ChainManager<REQUEST_TYPE> AppendHandlerToChain(IChainHandler<REQUEST_TYPE> handler)
        {
            if (!handlerChain.Contains(handler))
                handlerChain.Add(handler);

            return this;
        }

        public ChainManager<REQUEST_TYPE> RemoveHandlerFromChain(params IChainHandler<REQUEST_TYPE>[] handlers)
        {
            foreach (IChainHandler<REQUEST_TYPE> handler in handlers)
            {
                RemoveHandlerFromChain(handler);
            }
            return this;
        }

        public ChainManager<REQUEST_TYPE> RemoveHandlerFromChain(IChainHandler<REQUEST_TYPE> handler)
        {
            if (handlerChain.Contains(handler))
                handlerChain.Remove(handler);

            return this;
        }

        /// <summary>
        /// Process chain request and return handle result, pass a list to get all exception message 
        /// </summary>
        /// <param name="requestData">Request data defined by <paramref name="REQUEST_TYPE"/></param>
        /// <param name="chainHandlerExceptionList">Return exception in chains all</param>
        /// <returns></returns>
        public HandlerResult ProcessRequest(REQUEST_TYPE requestData, out List<ChainHandlerException> chainHandlerExceptionList)
        {
            chainHandlerExceptionList = new List<ChainHandlerException>();

            foreach (IChainHandler<REQUEST_TYPE> handler in handlerChain)
            {
                try
                {
                    var result = handler.ProcessRequest(requestData);
                }
                catch (ChainHandlerException ex)
                {
                    chainHandlerExceptionList.Add(ex);
                    if (StopOnFirstException)
                    {
                        break;
                    }
                }
            }

            return chainHandlerExceptionList.Count == 0 ? HandlerResult.CHAIN_DATA_HANDLED : HandlerResult.CHAIN_DATA_NOT_HANDLED;
        }
    }
}
