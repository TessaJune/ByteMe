using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public interface ISearch
    {
        public Task<IReadOnlyCollection<ResourceDto>> SearchAll();
        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilter(string type);
        public Task<IReadOnlyCollection<ResourceDto>> SearchByFilters(IEnumerable<string> type);
        public Task<IReadOnlyCollection<ResourceDto>> SearchByYear(int year);
    }
}