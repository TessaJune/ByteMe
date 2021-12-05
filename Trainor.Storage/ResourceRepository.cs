using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public class ResourceRepository : IResourceRepository
    {

        public Task<(CrudStatus, ResourceCreateDto)> CreateAsync(ResourceCreateDto resource)
        {
            throw new NotImplementedException();
        }

        public Task<CrudStatus> DeleteAsync(int resourceId)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceDto> ReadAsync(int resourceId)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<ResourceDto>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CrudStatus> UpdateAsync(ResourceDto resource)
        {
            throw new NotImplementedException();
        }
    }
}