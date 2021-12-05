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

        public async Task<(CrudStatus, UserDetailsDto)> CreateAsync(UserCreateDto user)
        {
            var entity = new User
            {
                Id = user.Id,
                GivenName = user.GivenName,
                LastName = user.LastName,
                Email = user.Email,
            };

            _context.Users.Add(entity);

            await _context.SaveChangesAsync();

            return (Created, new UserDetailsDto(
                entity.Id,
                entity.GivenName,
                entity.LastName,
                entity.Email
                ));
        }

        public async Task<UserDetailsDto> ReadDetailsAsync(int userId)
        {
            var users = from u in _context.Users
                        where u.Id == userId
                        select new UserDetailsDto(
                            u.Id,
                            u.GivenName,
                            u.LastName,
                            u.Email
                        );

            return await users.FirstOrDefaultAsync();
        }

        public async Task<UserDto> ReadAsync(int userId)
        {
            var users = from u in _context.Users
                        where u.Id == userId
                        select new UserDto(
                            u.Id,
                            u.GivenName,
                            u.LastName
                        );

            return await users.FirstOrDefaultAsync();
        }
        
        public async Task<IReadOnlyCollection<UserDto>> ReadAsync() =>
            (await _context.Users
                    .Select(u => new UserDto(u.Id, u.GivenName, u.LastName))
                    .ToListAsync())
                    .AsReadOnly();
    
        public async Task<CrudStatus> UpdateAsync(int id, UserUpdateDto user) // Missing "await" in method body 
        {
            var entity = await _context.Users.Include(u => u.Id).FirstOrDefaultAsync(u => u.Id == user.Id);
            
            if (entity == null)
            {
                return NotFound;
            }

            entity.Id = user.Id;
            entity.GivenName = user.GivenName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;

            await _context.SaveChangesAsync();

            return Updated;
        }

        public async Task<CrudStatus> DeleteAsync(int userId) // Missing "await" in method body
        {
            var entity = await _context.Users.FindAsync(userId);

            if (entity == null)
            {
                return NotFound;
            }

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();

            return Deleted;
        }
    }
}