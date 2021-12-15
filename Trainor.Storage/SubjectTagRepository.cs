using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Trainor.Storage.Entities;
using static Trainor.Storage.CrudStatus;
using Microsoft.EntityFrameworkCore;
namespace Trainor.Storage
{
    public class SubjectTagRepository : ISubjectTagRepository
    {
        private readonly IDataContext _context;

        public SubjectTagRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<(CrudStatus, SubjectTagDto)> CreateAsync(SubjectTagCreateDto subjectTag)
        {
            var entity = new SubjectTag
            {
                Id = subjectTag.Id,
                Title = subjectTag.Title,
            };

            _context.SubjectTags.Add(entity);

            await _context.SaveChangesAsync();

            return (Created, new SubjectTagDto(
                entity.Id,
                entity.Title
                ));
        }

        public async Task<(CrudStatus, SubjectTagDto)> ReadAsync(int subjectTagId)
        {
                   var entity = await _context.SubjectTags
                                              .Where(s => s.Id == subjectTagId)
                                              .Select(s => new SubjectTagDto(s.Id, s.Title))
                                              .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);
        }
        
        public async Task<(CrudStatus, IReadOnlyCollection<SubjectTagDto>)> ReadAsync() 
        {
            var entities = (await _context.SubjectTags
                                          .Select(s => new SubjectTagDto(s.Id, s.Title))
                                          .ToListAsync())
                                          .AsReadOnly();

            if (entities == null)
                return (NotFound, null);
            
            return (Ok, entities);
        }
    
        public async Task<CrudStatus> UpdateAsync(SubjectTagUpdateDto SubjectTag)
        {
            var entity = (await _context.SubjectTags
                                        .FindAsync(SubjectTag.Id));

            if (entity == null)
                return NotFound;
            
    
            entity.Id = SubjectTag.Id;
            entity.Title = SubjectTag.Title;

            await _context.SaveChangesAsync();

            return Updated;
        }

        public async Task<CrudStatus> DeleteAsync(int subjectTagId)
        {
            var entity = (await _context.SubjectTags
                                        .FindAsync(subjectTagId));
                        

            if (entity == null)
                return NotFound;
            

            _context.SubjectTags.Remove(entity);
            await _context.SaveChangesAsync();

            return Deleted;
        }
    }
}