using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.App;
using Trainor.App.Entities;

namespace Trainor.Storage
{
    public interface IResourceRepository
    {
        Task<(Status, Resource)> CreateAsync(ResourceCreateDto resource);
        Task<ResourceDto> ReadAsync(int resourceId);
        Task<IReadOnlyCollection<ResourceDto>> ReadAsync();
        Task<Status> UpdateAsync(ResourceDto resource);
        Task<Status> DeleteAsync(int resourceId);
    }
}