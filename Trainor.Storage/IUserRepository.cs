using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.App;
using Trainor.App.Entities;

namespace Trainor.Storage
{
    public interface IUserRepository
    {
        Task<(Status, User)> CreateAsync(UserCreateDto user);
        Task<UserDto> ReadAsync(int userId);
        Task<IReadOnlyCollection<UserDto>> ReadAsync();
        Task<Status> UpdateAsync(UserDto user);
        Task<Status> DeleteAsync(int userId);
    }
}