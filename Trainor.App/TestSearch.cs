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

        public Task<IReadOnlyCollection<ResourceDto>> SearchByType(string type)
        {
            return SeedSearch();
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchBySubject(IEnumerable<string> type)
        {
            return SeedSearch();
        }

        public Task<IReadOnlyCollection<ResourceDto>> SearchByYear(int year)
        {
            return SeedSearch();
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
    }
}