using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Settings.Network;

namespace AMR_Server.Controllers
{
    [Route("Api/Network")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        public NetworkController()
        {
        }

        [HttpGet]
        [Route("GetDevices")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]

        public async Task<IActionResult> GetDevices(string hostIp)
        {
            //NetworkHelper.PingAll();
            //var lstDevices = NetworkHelper.lstDevices;

            bool isConntectedToDomain = NetworkHelper.IsConnectedToDomain(hostIp);
            return StatusCode(200, isConntectedToDomain);
        }
    }
}
