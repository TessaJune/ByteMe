using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IReadOnlyCollection<ResourceDto>> ReadAsync()
        {
            return (await _context.Resources
                                  .Select(r => new ResourceDto(r.Name, r.Authors))
                                  .ToListAsync())
                                  .AsReadOnly();
        }

        public async Task<(CrudStatus, ResourceDto)> ReadAsync(int resourceId)
        {
            var entity = await _context.Resources
                                    .Where(r => r.Id == resourceId)
                                    .Select(r => new ResourceDto(r.Name, r.Authors))
                                    .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);

        }

        public async Task<(CrudStatus, ResourceDetailsDto)> ReadDetailsAsync(int resourceId)
        {
            var entity = await _context.Resources
                                    .Where(r => r.Id == resourceId)
                                    .Select(r => new ResourceDetailsDto(r.Name, r.Link, r.Authors, r.Type, r.Subjects, r.Date))
                                    .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);
        }

        //TODO: How should this method work? Give ID + UpdateDTO to change ID => new details?
        public async Task<CrudStatus> UpdateAsync(ResourceUpdateDto resource)
        {
            var entity = await _context.Resources.FindAsync(resource.Id);

            if (entity == null)
            {
                return NotFound;
            }

            entity.Name = resource.Name;
            entity.Link = resource.Link;
            entity.Authors = resource.Authors;
            entity.Type = resource.Type;
            entity.Subjects = resource.Subjects;
            entity.Date = resource.Date;

            await _context.SaveChangesAsync();

            return Updated;
        }

        public async Task<CrudStatus> DeleteAsync(int resourceId)
        {
            var resource = await _context.Resources
                                         .Include(r => r.Id)
                                         .FirstOrDefaultAsync(r => r.Id == resourceId);
            if (resource == null)
                return NotFound;

            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();

            return Deleted;
        }
    }
}