using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Trainor.Wasm.Shared;
using Trainor.Storage.Entities;

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
        public IEnumerable<ResourceDto> Get()
        {/*
            String[] authors = {
                "Simon L.K.",
                "Tessa J.S."
            };
            ResourceDto[] resourceDtos = {
                new ResourceDto("Article1", authors),
                new ResourceDto("Article2", authors),
                new ResourceDto("Article3", authors),
                new ResourceDto("Article4", authors)
            };*/
            return null;
        }
    }
}
