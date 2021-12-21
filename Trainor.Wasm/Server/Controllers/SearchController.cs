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

    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearch _search;

        public SearchController(ILogger<SearchController> logger, ISearch search)
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
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> Get([FromQuery (Name = "filters")]string[] filters)
        {
            if (filters.Length == 0) Console.WriteLine("That shit empty");
            foreach (string filter in filters)
            {
                Console.WriteLine(filter);
            }

            List<ResourceDto> searchResult = (List<ResourceDto>)await _search.SearchByFilters(filters);

            if (searchResult.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return searchResult;
        }
    }
}
