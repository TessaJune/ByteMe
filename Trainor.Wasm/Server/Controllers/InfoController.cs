using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Trainor.Wasm.Shared;

namespace Trainor.Wasm.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class InfoController : ControllerBase
    {
        private readonly ILogger<InfoController> _logger;
        private readonly IConfiguration _config;

        // The Web API will only accept tokens 1) for users, and 2) having the "API.Access" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "API.Access" };

        public InfoController(ILogger<InfoController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public string Get()
        {
            return _config.GetConnectionString("Trainor");
        }
    }
}
