using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainor.App
{
    public class Search : ISearch
    {
        I
        private IEnumerable<Resource> GetBySearchQuery(IEnumerable<Predicate<Resource>> predicates) {

        } 

        public IEnumerable<Resource> GetByID(string searchId) {
            GetBySearchQuery(p => resource.Id == searchId);
        }

        public IEnumerable<Resource> GetByName(string searchId) {
            GetBySearchQuery(p => resource.Id == searchId);
        }

    }
}