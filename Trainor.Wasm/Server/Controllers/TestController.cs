using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Trainor.Wasm.Shared;

namespace Trainor.Wasm.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
    
        private readonly ILogger<TestController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "API.Access" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "API.Access" };

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<DateTime> Get()
        {
            DateTime[] dateTimeArray = {
                new DateTime(2010,10,10),
                new DateTime(2011,11,10),
                new DateTime(2012,12,10),
                new DateTime(2013,10,10),
            };
            return dateTimeArray;
        }
    }
}
