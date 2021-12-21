using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public class TestSearch : ISearch
    {
        public Task<IReadOnlyCollection<ResourceDto>> SearchAll()
        {
            return SeedSearch();
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilter(string filter)
        {
            return SeedSearch(filter);
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilters(IEnumerable<string> filters)
        {
            return SeedSearch(filters);
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByYear(int year)
        {
            return SeedSearch();
        }

        private async Task<IReadOnlyCollection<ResourceDto>> SeedSearch()
        {
            List<ResourceDto> returnList = new List<ResourceDto>();
            returnList.Add(new ResourceDto(0, "Title1", "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(1, "Title2", "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(2, "Title3", "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(3, "Title4", "www.www.com", null, null, null, null));
            returnList.Add(new ResourceDto(4, "Title5", "www.www.com", null, null, null, null));
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