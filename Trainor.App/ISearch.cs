using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainor.App
{
    public interface ISearch
    {
        private IEnumerable<T> GetBySearchQuery(IEnumerable<Predicate<T>> predicates){}
      
    }
}