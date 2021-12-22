using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            => await _search.SearchAllAsync();

        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int)HttpStatusCode.OK)]
        [HttpGet("{queryString}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> Get(string queryString)
        {
            ReadOnlyCollection<ResourceDto> searchResult;
            if (queryString.Contains('&'))
            {
                string[] filters = queryString.Split("&");
                searchResult = (ReadOnlyCollection<ResourceDto>)await _search.QueryRepoFilteredAsync(filters);
                if (searchResult.IsNullOrEmpty())
                {
                    return new NotFoundResult();
                }
                return searchResult;
            }
            if (queryString.Contains(' '))
            {
                string[] filters = queryString.Split(" ");

                searchResult = (ReadOnlyCollection<ResourceDto>)await _search.QueryRepoKeywordsAsync(filters);
                if (searchResult.IsNullOrEmpty())
                {
                    return new NotFoundResult();
                }
                return searchResult;
            }

            searchResult = (ReadOnlyCollection<ResourceDto>)await _search.QueryRepoKeywordsAsync(new []{queryString});
            if (searchResult.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return searchResult;
        }
    }
}
