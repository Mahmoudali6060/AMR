using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Shared.Entities;

namespace RealTimeCharts_Server.Controllers
{
    [Route("Api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserDetailDAL _userDetailDAL;//TO DO
        public UserController(IUserDetailDAL userDetailDAL)
        {
            _userDetailDAL = userDetailDAL;
        }

        [HttpPost]
        [Route("GetAllUserDetails")]
        public async Task<IActionResult> GetAllUserDetails([FromBody] DataSource dataSource)
        {
            var userDetails = await _userDetailDAL.GetAllUser(dataSource);
            return StatusCode(200, userDetails);
        }
    }

}
