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
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<(CrudStatus, UserDto)> CreateAsync(UserCreateDto user)
        {
            var entity = new User
            {
                GivenName = user.GivenName,
                LastName = user.LastName,
                Email = user.Email,
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync();

            return (Created, new UserDto(
                entity.Id,
                entity.GivenName,
                entity.LastName,
                entity.Email
                ));
        }

        public async Task<(CrudStatus, UserDto)> ReadAsync(int userId)
        {
                   var entity = await _context.Users
                                              .Where(u => u.Id == userId)
                                              .Select(u => new UserDto(u.Id, u.GivenName, u.LastName, u.Email))
                                              .FirstOrDefaultAsync();

            if (entity == null)
                return (NotFound, null);

            return (Ok, entity);
        }
        
        public async Task<(CrudStatus, IReadOnlyCollection<UserDto>)> ReadAsync() 
        {
            var entities = (await _context.Users
                                          .Select(u => new UserDto(u.Id, u.GivenName, u.LastName, u.Email))
                                          .ToListAsync())
                                          .AsReadOnly();

            if (entities == null)
                return (NotFound, null);
            
            return (Ok, entities);
        }
    
        public async Task<CrudStatus> UpdateAsync(UserUpdateDto user)
        {
            var entity = (await _context.Users
                                        .FindAsync(user.Id));

            if (entity == null)
                return NotFound;
            
    
            entity.GivenName = user.GivenName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;

            await _context.SaveChangesAsync();

            return Updated;
        }

        public async Task<CrudStatus> DeleteAsync(int userId)
        {
            var entity = (await _context.Users
                                        .FindAsync(userId));
                        

            if (entity == null)
                return NotFound;
            

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return Deleted;
        }
    }
}