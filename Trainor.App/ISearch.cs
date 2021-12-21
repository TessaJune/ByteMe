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
        public Task<IReadOnlyCollection<ResourceDto>> SearchAllAsync();
        public Task<IReadOnlyCollection<ResourceDto>> QueryRepoFilteredAsync(IEnumerable<string> filter);
        public Task<IReadOnlyCollection<ResourceDto>> QueryRepoKeywordsAsync(IEnumerable<string> searchWords);


    }
}