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

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> ReadAsync()
        {
            /*var entities = (await _context.Resources
                                          .Select(r => new ResourceDto(r.Name, r.Authors))
                                          .ToListAsync())
                                          .AsReadOnly();

            if (entities == null)
                return (NotFound, null);

            return (Ok, entities);*/
            throw new NotImplementedException();
        }

        public async Task<(CrudStatus, ResourceDto)> ReadAsync(int resourceId)
        {
            /*
            var entity = await _context.Resources
                                       .Where(r => r.Id == resourceId)
                                       .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors, r.Subjects, r.Type, r.Date))
                                       .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);*/
            throw new NotImplementedException();
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

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> ReadFromKeyword(string keyword){
            /*var entities = (await _context.Resources
                                        .Where(r => r.Name.Contains(keyword) || r.Link.Contains(keyword) || r.Authors. ||
                                         r.Type.ToString().Contains(keyword) || r.Subjects.ToString().Contains(keyword))
                                        .Select(r => new ResourceDto(r.Id, r.Name, r.Link, r.Authors, r.Type, r.Subjects, r.Date))
                                        .ToListAsync())
                                        .AsReadOnly();
            //Changed to DetailsDTO, remmeber to match on all parameters.
            
            if (entities == null)
                return (NotFound, null);

            return (Ok, entities);*/
            throw new NotImplementedException();
        }

        /*private string GetAuthors(IEnumerable<Author> authors)
        {
            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                return author.GivenName;
            }
        }*/

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> ReadFromFilters(TypeTag filterTags)
        {
            /*
            var entities = (await _context.Resources
                                        .Where(r => r.Type == filterTags)
                                        .Select(r => new ResourceDto(r.Id,r.Name,r.Link, r.Authors, r.Type, r.Subjects, r.Date))
                                        .ToListAsync())
                                        .AsReadOnly();
            if (entities == null)
                return (NotFound, null);

            return (Ok, entities); */
            throw new NotImplementedException();
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto?>)> ReadFromFilters(IEnumerable<SubjectTag> filterTags)
        {
            /*
            var entities = (await _context.Resources
                                        .Where(r => r.Subjects == filterTags)
                                        .Select(r => new ResourceDto(r.Id,r.Name,r.Link, r.Authors, r.Type, r.Subjects, r.Date))
                                        .ToListAsync())
                                        .AsReadOnly();
            if (entities == null)
                return (NotFound, null);

            return (Ok, entities);*/
            throw new NotImplementedException();
        }

        public async Task<(CrudStatus, IReadOnlyCollection<ResourceDto?>)> ReadFromFilters(TypeTag typeFilter, IEnumerable<SubjectTag> subjectFilter)
        {
            /*var entities = (await _context.Resources
                                        .Where(r => r.Type == typeFilter && r.Subjects == subjectFilter)
                                        .Select(r => new ResourceDto(r.Id,r.Name,r.Link, r.Authors, r.Type, r.Subjects, r.Date))
                                        .ToListAsync())
                                        .AsReadOnly();
            if (entities == null)
                return (NotFound, null);

            return (Ok, entities);
            //No search methods are fully implemented yet.*/
            throw new NotImplementedException();
        }
    }
}