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

        public async Task<(CrudStatus, ResourceDto)> CreateAsync(ResourceCreateDto resource)
        {
            /*var entity = new Resource
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

            return (Created, new ResourceDto(
                                 entity.Id,
                                 entity.Name,
                                 entity.Link,
                                 entity.Authors,
                                 entity.Subjects,
                                 entity.Type,
                                 entity.Date
                             ));*/
            throw new NotImplementedException();
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>?)> ReadAsync()
        {
            var entities = (await _context.Resources
                                          .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                                          .ToListAsync())
                                          .AsReadOnly();

            if (entities == null || entities.Count == 0)
                return (NotFound, null);

            return (Ok, entities);
        }

        public async Task<(CrudStatus, ResourceDto?)> ReadAsync(int resourceId)
        {
            var entity = await _context.Resources
                                       .Where(r => r.Id == resourceId)
                                       .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                                       .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);
        }

        public async Task<CrudStatus> UpdateAsync(ResourceUpdateDto resource)
        {
            /*var entity = await _context.Resources
                                       .FindAsync(resource.Id);

            if (entity == null)
                return NotFound;

            entity.Name = resource.Name;
            entity.Link = resource.Link;
            entity.Authors = resource.Authors;
            entity.Type = resource.Type;
            entity.Subjects = resource.Subjects;
            entity.Date = resource.Date;

            await _context.SaveChangesAsync();

            return Updated;*/
            throw new NotImplementedException();
        }

        public async Task<CrudStatus> DeleteAsync(int resourceId)
        {
            /* var entity = await _context.Resources
                                        .FindAsync(resourceId);
             if (entity == null)
                 return NotFound;

             _context.Resources.Remove(entity);
             await _context.SaveChangesAsync();

             return Deleted;*/
            throw new NotImplementedException();
        }

        //Unsure if we can use anyResourceAttributeContainsAnyKeyword without asking db for all data
        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>?)> ReadFromKeywordsAsync(IEnumerable<string> keywords)
        {
            Func<Resource, bool> anyResourceAttributeContainsAnyKeyword = r =>
            {
                var resourceAttributes = new List<string>();
                resourceAttributes.AddRange(r.Authors.Select(a => a.GivenName));
                resourceAttributes.AddRange(r.Authors.Select(a => a.LastName));
                resourceAttributes.Add(r.Name);
                resourceAttributes.Add(r.Link);
                resourceAttributes.Add(r.Type.ToString());
                resourceAttributes.Add(r.Subject.ToString());

                foreach (var resource in resourceAttributes)
                {
                    foreach (var keyword in keywords)
                    {
                        var resourceLowerCase = resource.ToLower();
                        var keywordLowerCase = keyword.ToLower();

                        if (resourceLowerCase.Contains(keywordLowerCase))
                        {
                            return true;
                        }
                    }
                }

                return false;
            };

            var entities = (await _context.Resources
                                .ToListAsync())
                                .Where(anyResourceAttributeContainsAnyKeyword)
                                .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                                .ToList()
                                .AsReadOnly();

            if (entities == null || entities.Count == 0)
                return (NotFound, null);

            return (Ok, entities);
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>?)> ReadFromFiltersAsync(IEnumerable<TypeTag> typeTags)
        {
            var entities = (await _context.Resources
                            .Where(r => typeTags.Contains(r.Type))
                            .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                            .ToListAsync())
                            .AsReadOnly();

            if (entities == null || entities.Count == 0)
                return (NotFound, null);

            return (Ok, entities);
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>?)> ReadFromFiltersAsync(IEnumerable<SubjectTag> subjectTags)
        {
            var entities = (await _context.Resources
                            .Where(r => subjectTags.Contains(r.Subject))
                            .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                            .ToListAsync())
                            .AsReadOnly();

            if (entities == null || entities.Count == 0)
                return (NotFound, null);

            return (Ok, entities);
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>?)> ReadFromFiltersAsync(IEnumerable<TypeTag> typeTags, IEnumerable<SubjectTag> subjectTags)
        {
            var entities = (await _context.Resources
                            .Where(r => subjectTags.Contains(r.Subject) && typeTags.Contains(r.Type))
                            .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors.AsDto(), r.Subject, r.Type, r.Date))
                            .ToListAsync())
                            .AsReadOnly();

            if (entities == null || entities.Count == 0)
                return (NotFound, null);

            return (Ok, entities);
        }
    }
}