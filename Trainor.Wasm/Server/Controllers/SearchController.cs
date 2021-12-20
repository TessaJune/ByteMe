using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using Trainor.Storage;
using Trainor.Storage.Entities;
using Trainor.App;
using Trainor.Wasm.Shared;

namespace Trainor.Wasm.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class ResourceController : ControllerBase
    {
        private readonly ILogger<ResourceController> _logger;
        private readonly ISearch _search;

        public ResourceController(ILogger<ResourceController> logger, ISearch search)
        {
            _logger = logger;
            _search = search;
        }
        
        [HttpGet]
        public async Task<IReadOnlyCollection<ResourceDto>> Get()
            => await _search.SearchAll();

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int)HttpStatusCode.OK)]
        [HttpGet("{filter}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> Get(string filter)
        {
            List<ResourceDto> searchResult = (List<ResourceDto>)await _search.SearchByFilter(filter);
            if (searchResult.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return searchResult;
        }
        
        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet("filtered")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> Get([FromQuery]string[] filters)
        {
            List<ResourceDto> searchResult = (List<ResourceDto>)await _search.SearchByFilters(filters);
            if (searchResult.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return searchResult;
        }
    }
}
