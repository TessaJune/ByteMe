using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.App.Entities;

namespace Trainor.Storage
{
    public class ResourceRepository : IResourceRepository
    {

        public Task<(Status, Resource)> CreateAsync(ResourceCreateDto resource)
        {
            throw new System.NotImplementedException();
        }

        public Task<Status> DeleteAsync(int resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ResourceDto> ReadAsync(int resourceId)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<ResourceDto>> ReadAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Status> UpdateAsync(ResourceDto resource)
        {
            throw new System.NotImplementedException();
        }
    }
}