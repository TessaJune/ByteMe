using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public interface IUserRepository
    {
        Task<(CrudStatus, UserCreateDto)> CreateAsync(UserCreateDto user);
        Task<UserDto> ReadAsync(int userId);
        Task<IReadOnlyCollection<UserDto>> ReadAsync();
        Task<CrudStatus> UpdateAsync(UserDto user);
        Task<CrudStatus> DeleteAsync(int userId);
    }
}