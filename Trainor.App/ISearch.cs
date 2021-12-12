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
        public Task<IReadOnlyCollection<ResourceDetailsDto>> SearchByType(string type);
        public Task<IReadOnlyCollection<ResourceDetailsDto>> SearchBySubject(IEnumerable<string> type);
        public Task<IReadOnlyCollection<ResourceDetailsDto>> SearchByYear(int year);
    }
}