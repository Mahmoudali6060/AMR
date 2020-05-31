using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Account.Services;
using DataBase.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Settings.Network;

namespace AMR_Server.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [Route("Authenticate")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]

        public async Task<IActionResult> Authenticate([FromBody] User loggedUser)
        {
            var user = _accountService.Authenticate(loggedUser);
            return StatusCode(200, user);
        }



    }
}
