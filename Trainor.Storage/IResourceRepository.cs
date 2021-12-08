using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trainor.Storage
{
    public interface IResourceRepository
    {
        Task<(CrudStatus, ResourceCreateDto)> CreateAsync(ResourceCreateDto resource);
        Task<ResourceDto> ReadAsync(int resourceId);
        Task<IReadOnlyCollection<ResourceDto>> ReadAsync();
        Task<CrudStatus> UpdateAsync(ResourceDto resource);
        Task<CrudStatus> DeleteAsync(int resourceId);
    }
}