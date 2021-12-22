using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web.Resource;
using Microsoft.IdentityModel.Tokens;
using Trainor.App;
using Trainor.Storage;
using Trainor.Storage.Entities;
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
        private readonly IResourceRepository _repo;

        public SearchController(ILogger<SearchController> logger, IResourceRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> Get()
        {
            var entities = (await _repo.ReadAsync()).Item2;
            if (entities.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return Ok(entities);
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet("keyword/{queryString}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> GetKeywords(string search)
        {
            var keywords = search.Split("+");

            var entities = (await _repo.ReadFromKeywordsAsync(keywords)).Item2;
            if (entities.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return Ok(entities);
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet("subjecttag/{queryString}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> GetSubjectTags(string search)
        {
            var subjectTags = new List<SubjectTag>();

            var tags = search.Split("+");
            foreach (var tag in tags)
            {
                if (tag == null || tag == string.Empty)
                {
                    continue;
                }

                var subjectTag = (SubjectTag) Enum.Parse(typeof(SubjectTag), tag, ignoreCase: true);
                subjectTags.Add(subjectTag);
            }

            var entities = (await _repo.ReadFromFiltersAsync(subjectTags)).Item2;
            if (entities.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return Ok(entities);
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet("typetag/{queryString}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> GetTypeTags(string search)
        {
            var typeTags = new List<TypeTag>();

            var tags = search.Split("+");
            foreach (var tag in tags)
            {
                if (tag == null || tag == string.Empty)
                {
                    continue;
                }

                var typeTag = (TypeTag) Enum.Parse(typeof(TypeTag), tag, ignoreCase: true);
                typeTags.Add(typeTag);
            }

            var entities = (await _repo.ReadFromFiltersAsync(typeTags)).Item2;
            if (entities.IsNullOrEmpty())
            {
                return new NotFoundResult();
            }
            return Ok(entities);
        }

        [ProducesResponseType((int) HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IReadOnlyCollection<ResourceDto>), (int) HttpStatusCode.OK)]
        [HttpGet("tags/{queryString}")]
        public async Task<ActionResult<IReadOnlyCollection<ResourceDto>>> GetMixedTags(string search)
        {
            var typeTags = new List<TypeTag>();
            var subjectTags = new List<SubjectTag>();

            var x = HttpUtility.ParseQueryString(search);
            foreach (var key in x.AllKeys)
            {
                //continue implementation
            }

        }
    }
}
