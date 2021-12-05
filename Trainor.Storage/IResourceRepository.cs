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
        Task<ResourceDto> ReadAsync(int resourceId);
        Task<ResourceDetailsDto> ReadDetailsAsync(int resourceId);
        Task<IReadOnlyCollection<ResourceDto>> ReadAsync();
        Task<CrudStatus> UpdateAsync(ResourceCreateDto resource);
        Task<CrudStatus> DeleteAsync(int resourceId);
    }
}