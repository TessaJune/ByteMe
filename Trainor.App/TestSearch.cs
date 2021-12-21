using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public class TestSearch : ISearch
    {
        public Task<IReadOnlyCollection<ResourceDto>> SearchAllAsync()
        {
            return SeedSearch();
        }

        public Task<IReadOnlyCollection<ResourceDto>> QueryRepoFilteredAsync(IEnumerable<string> filters)
        {
            return SeedSearch(filters);
        }
        
        public Task<IReadOnlyCollection<ResourceDto>> QueryRepoKeywordsAsync(IEnumerable<string> keywords)
        {
            return SeedSearch(keywords);
        }

        private async Task<IReadOnlyCollection<ResourceDto>> SeedSearch()
        {
            List<ResourceDto> returnList = new List<ResourceDto>();
            returnList.Add(new ResourceDto(0, null, "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(1, null, "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(2, null, "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(3, null, "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(4, null, "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(5, null, "www.www.com", null, null, null, null));
            return returnList;
        }

        private async Task<IReadOnlyCollection<ResourceDto>> SeedSearch(string filter)
        {
            List<ResourceDto> returnList = new List<ResourceDto>();
            returnList.Add(new ResourceDto(0, null, "www.www.filters", null, null, null, null));
            returnList.Add(new ResourceDto(returnList.Count, null, "www.www." + filter, null, null, null, null));
            returnList.Add(new ResourceDto(returnList.Count, null, "www.www.filters", null, null, null, null));
            return returnList;
        }
        
        private async Task<IReadOnlyCollection<ResourceDto>> SeedSearch(IEnumerable<string> filters)
        {
            List<ResourceDto> returnList = new List<ResourceDto>();
            returnList.Add(new ResourceDto(0, null, "www.www.filters", null, null, null, null));
            foreach (string filter in filters)
            {
                returnList.Add(new ResourceDto(returnList.Count, null, "www.www." + filter, null, null, null, null));
            }
            returnList.Add(new ResourceDto(returnList.Count, null, "www.www.filters", null, null, null, null));
            return returnList;
        }
    }
}