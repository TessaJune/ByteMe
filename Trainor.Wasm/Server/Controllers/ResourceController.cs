using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Trainor.Storage;
using Trainor.Storage.Entities;
using Trainor.Wasm.Shared;

namespace Trainor.Wasm.Server.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;
        private readonly IResourceRepository _repo;

        // The Web API will only accept tokens 1) for users, and 2) having the "API.Access" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "API.Access" };

        public ResourceController(ILogger<ResourceController> logger, IResourceRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> Get()
        {
            _logger.LogInformation("bim bam get of the testcontroller has been slam");
            return _repo.ReadAsync();
        }

        private Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> GetFromRepo()
        {
            return _repo.ReadAsync();
        }
    }
}
