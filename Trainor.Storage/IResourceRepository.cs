using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public interface IResourceRepository
    {
        Task<(CrudStatus, ResourceDetailsDto)> CreateAsync(ResourceCreateDto resource);
        Task<IReadOnlyCollection<ResourceDto>> ReadAsync();
        Task<(CrudStatus, ResourceDto)> ReadAsync(int resourceId);
        Task<(CrudStatus, ResourceDetailsDto)> ReadDetailsAsync(int resourceId);
        Task<CrudStatus> UpdateAsync(ResourceUpdateDto resource);
        Task<CrudStatus> DeleteAsync(int resourceId);
    }
}