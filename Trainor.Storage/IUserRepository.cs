using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public interface IUserRepository
    {
        Task<(CrudStatus, UserDto)> CreateAsync(UserCreateDto user);

        Task<(CrudStatus, UserDto)> ReadAsync(int userId);

        Task<(CrudStatus, IReadOnlyCollection<UserDto>)> ReadAsync();

        Task<CrudStatus> UpdateAsync(UserUpdateDto user);
        
        Task<CrudStatus> DeleteAsync(int userId);
    }
}