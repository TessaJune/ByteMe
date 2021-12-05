using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
using static Trainor.Storage.CrudStatus;

namespace Trainor.Storage
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContext _context;

        public UserRepository(IDataContext context)
        {
            _context = context;
        }

        public Task<(CrudStatus, UserDetailsDto)> CreateAsync(UserCreateDto user)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> ReadAsync(int userId) 
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailsDto> ReadDetailsAsync(int userId) 
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyCollection<UserDto>> ReadAsync() 
        {
            throw new NotImplementedException();
        }

        public Task<CrudStatus> UpdateAsync(UserCreateDto user) 
        {
            throw new NotImplementedException();
        }

        public Task<CrudStatus> DeleteAsync(int userId) {
            throw new NotImplementedException();
        }
    }
}