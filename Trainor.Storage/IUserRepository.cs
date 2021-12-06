using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public interface IUserRepository
    {
        Task<(CrudStatus, UserDetailsDto)> CreateAsync(UserCreateDto user);

        Task<(CrudStatus, UserDetailsDto)> ReadDetailsAsync(int userId);

        Task<(CrudStatus, UserDto)> ReadAsync(int userId);

        Task<(CrudStatus, IReadOnlyCollection<UserDto>)> ReadAsync();

        Task<CrudStatus> UpdateAsync(UserUpdateDto user);
        
        Task<CrudStatus> DeleteAsync(int userId);
    }
}