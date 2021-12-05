using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
using static Trainor.Storage.CrudStatus;

namespace Trainor.Storage
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly IDataContext _context;

        public ResourceRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<(CrudStatus, ResourceDetailsDto)> CreateAsync(ResourceCreateDto resource)
        {
            var entity = new Resource
            {
                Name = resource.Name,
                Link = resource.Link,
                Authors = resource.Authors,
                Type = resource.Type,
                Subjects = resource.Subjects,
                Date = resource.Date
            };

            _context.Resources.Add(entity);

            await _context.SaveChangesAsync();

            return (Created, new ResourceDetailsDto(
                                 entity.Name,
                                 entity.Link,
                                 entity.Authors,
                                 entity.Type,
                                 entity.Subjects,
                                 entity.Date
                             ));
        }

        public Task<CrudStatus> DeleteAsync(int resourceId)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceDetailsDto> ReadDetailsAsync(int resourceId)
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

        public Task<CrudStatus> UpdateAsync(ResourceCreateDto resource)
        {
            throw new NotImplementedException();
        }
    }
}