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

        Task<UserDetailsDto> ReadDetailsAsync(int userId);

        Task<UserDto> ReadAsync(int userId);

        Task<IReadOnlyCollection<UserDto>> ReadAsync();

        Task<CrudStatus> UpdateAsync(int id, UserUpdateDto user);
        
        Task<CrudStatus> DeleteAsync(int userId);
    }
}