using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.App.Entities;

namespace Trainor.App
{
    public class Search : ISearch
    {

        private IEnumerable<Resource> GetBySearchQuery(Func<Resource, Resource, bool> property)
        {
            throw new NotImplementedException();
        }

    }
}