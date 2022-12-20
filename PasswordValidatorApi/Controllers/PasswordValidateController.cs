using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordValidatorApi.Models;
using PasswordValidatorApi.Models.ChainManagement;
using PasswordValidatorApi.Models.HandlerChain;

namespace PasswordValidatorApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PasswordValidateController : ControllerBase
    {
        private ChainManager _chainManager;

        public PasswordValidateController(ChainManager chainManager)
        {
            _chainManager = chainManager;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Validate([FromBody] string password)
        {
            List<ChainHandlerException> validationExceptions;
            return Ok(_chainManager.ProcessRequest(password, out validationExceptions) == HandlerResult.CHAIN_DATA_HANDLED);
        }

    }
}
