using PasswordValidatorApi.Models.HandlerChain;
using System.Collections.Generic;

namespace PasswordValidatorApi.Models.ChainManagement
{
    public class ChainManager
    {
        private List<IChainHandler> handlerChain = new List<IChainHandler>();

        private bool stopOnFirstHandlerException = false;
        public bool StopOnFirstException { get { return this.stopOnFirstHandlerException; } }
        public ChainManager(bool stopOnFirstHandlerException)
        {
            this.stopOnFirstHandlerException = stopOnFirstHandlerException;
        }
        public ChainManager AppendHandlerToChain(params IChainHandler[] handlers)
        {
            foreach (IChainHandler handler in handlers)
            {
                AppendHandlerToChain(handler);
            }
            return this;
        }

        public ChainManager AppendHandlerToChain(IChainHandler handler)
        {
            if (!handlerChain.Contains(handler))
                handlerChain.Add(handler);

            return this;
        }

        public ChainManager RemoveHandlerFromChain(params IChainHandler[] handlers)
        {
            foreach (IChainHandler handler in handlers)
            {
                RemoveHandlerFromChain(handler);
            }
            return this;
        }

        public ChainManager RemoveHandlerFromChain(IChainHandler handler)
        {
            if (handlerChain.Contains(handler))
                handlerChain.Remove(handler);

            return this;
        }

        public HandlerResult ProcessRequest(string requestData, out List<ChainHandlerException> chainHandlerExceptionList)
        {
            chainHandlerExceptionList = new List<ChainHandlerException>();

            foreach (IChainHandler handler in handlerChain)
            {
                try
                {
                    var result = handler.ProcessRequest(requestData);
                }
                catch (ChainHandlerException ex)
                {
                    chainHandlerExceptionList.Add(ex);
                    if (stopOnFirstHandlerException)
                    {
                        break;
                    }
                }
            }

            return chainHandlerExceptionList.Count == 0 ? HandlerResult.CHAIN_DATA_HANDLED : HandlerResult.CHAIN_DATA_NOT_HANDLED;
        }
    }
}
