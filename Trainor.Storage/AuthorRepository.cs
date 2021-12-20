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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly IDataContext _context;

        public AuthorRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<(CrudStatus, AuthorDto)> CreateAsync(AuthorCreateDto author)
        {
            var entity = new Author
            {
                Id = author.Id,
                GivenName = author.GivenName,
                LastName = author.LastName,
            };

            _context.Authors.Add(entity);

            await _context.SaveChangesAsync();

            return (Created, new AuthorDto(
                entity.Id,
                entity.GivenName,
                entity.LastName
                ));
        }
        
        public async Task<(CrudStatus, AuthorDto)> ReadAsync(int authorId)
        {
                   var entity = await _context.Authors
                                              .Where(a => a.Id == authorId)
                                              .Select(a => new AuthorDto(a.Id ,a.GivenName, a.LastName))
                                              .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);
        }
        
        public async Task<(CrudStatus, IReadOnlyCollection<AuthorDto>)> ReadAsync() 
        {
            var entities = (await _context.Authors
                                          .Select(a => new AuthorDto(a.Id, a.GivenName, a.LastName))
                                          .ToListAsync())
                                          .AsReadOnly();

            if (entities == null)
                return (NotFound, null);
            
            return (Ok, entities);
        }
    
        public async Task<CrudStatus> UpdateAsync(AuthorUpdateDto author)
        {
            var entity = (await _context.Authors
                                        .FindAsync(author.Id));

            if (entity == null)
                return NotFound;
            
            entity.Id = author.Id;
            entity.GivenName = author.GivenName;
            entity.LastName = author.LastName;

            await _context.SaveChangesAsync();

            return Updated;
        }

        public async Task<CrudStatus> DeleteAsync(int authorId)
        {
            var entity = (await _context.Authors
                                        .FindAsync(authorId));
                        

            if (entity == null)
                return NotFound;
            

            _context.Authors.Remove(entity);
            await _context.SaveChangesAsync();

            return Deleted;
        }
    }
}