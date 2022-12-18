using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PasswordValidatorApi.Models;

namespace PasswordValidatorApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PasswordValidateController : ControllerBase
    {
        private IPasswordValidator _validator;

        public PasswordValidateController(IPasswordValidator validator)
        {
            _validator = validator;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Validate([FromBody] string password)
        {
            return Ok(_validator.Validate(password));
        }

        [HttpGet]
        [Route("[action]")]
        public string SayHi()
        {
            return "HI1";
        }
    }
}
