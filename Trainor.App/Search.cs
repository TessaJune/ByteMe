using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public class Search : ISearch
    {
        public IEnumerable<ResourceDto> SearchByFilter(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResourceDto> SearchByKeyword(string keyword)
        {
            throw new NotImplementedException();
            //var resource = new DataContext(resource);
        }

        private IEnumerable<ResourceDetailsDto> GetBySearchQuery(Func<ResourceDetailsDto, ResourceDetailsDto, bool> property)
        {
            throw new NotImplementedException();
        }
    }
}