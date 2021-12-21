using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public class TestSearch : ISearch
    {
        public Task<IReadOnlyCollection<ResourceDto>> SearchAll()
        {
            return SeedSearch("all");
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilter(string filter)
        {
            return SeedSearch("filter");
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilters(IEnumerable<string> filters)
        {
            return SeedSearch("filters");
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByYear(int year)
        {
            return SeedSearch("");
        }

        private async Task<IReadOnlyCollection<ResourceDto>> SeedSearch(string searchType)
        {
            List<ResourceDto> returnList = new List<ResourceDto>();
            if (searchType == "all")
            {
                returnList.Add(new ResourceDto(0, "Title1", "www.www.com", null, null, null, null));
                returnList.Add(new ResourceDto(1, "Title2", "www.www.com", null, null, null, null));
                returnList.Add(new ResourceDto(2, "Title3", "www.www.com", null, null, null, null));
                returnList.Add(new ResourceDto(3, "Title4", "www.www.com", null, null, null, null));
                returnList.Add(new ResourceDto(4, "Title5", "www.www.com", null, null, null, null));
                returnList.Add(new ResourceDto(5, "Title6", "www.www.com", null, null, null, null));
            } 
            else if (searchType == "filter")
            {
                returnList.Add(new ResourceDto(0, null, "www.www.filter", null, null, null, null));
                returnList.Add(new ResourceDto(1, null, "www.www.filter", null, null, null, null));
                returnList.Add(new ResourceDto(2, null, "www.www.filter", null, null, null, null));
                returnList.Add(new ResourceDto(3, null, "www.www.filter", null, null, null, null));
                returnList.Add(new ResourceDto(4, null, "www.www.filter", null, null, null, null));
                returnList.Add(new ResourceDto(5, null, "www.www.filter", null, null, null, null));
            }
            else if (searchType == "filters")
            {
                returnList.Add(new ResourceDto(0, null, "www.www.filters", null, null, null, null));
                returnList.Add(new ResourceDto(1, null, "www.www.filters", null, null, null, null));
                returnList.Add(new ResourceDto(2, null, "www.www.filters", null, null, null, null));
                returnList.Add(new ResourceDto(3, null, "www.www.filters", null, null, null, null));
                returnList.Add(new ResourceDto(4, null, "www.www.filters", null, null, null, null));
                returnList.Add(new ResourceDto(5, null, "www.www.filters", null, null, null, null));
            }
            return returnList;
        }
    }
}