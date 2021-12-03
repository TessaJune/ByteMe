using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage;

namespace Trainor.App
{
    public class Search : ISearch
    {

        private IEnumerable<ResourceDetailsDto> GetBySearchQuery(Func<ResourceDetailsDto, ResourceDetailsDto, bool> property)
        {
            throw new NotImplementedException();
        }

    }
}