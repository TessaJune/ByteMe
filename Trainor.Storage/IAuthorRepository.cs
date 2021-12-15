using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public interface IAuthorRepository
    {
        Task<(CrudStatus, AuthorDto)> CreateAsync(AuthorCreateDto author);

        Task<(CrudStatus, AuthorDto)> ReadAsync(int authorId);

        Task<(CrudStatus, IReadOnlyCollection<AuthorDto>)> ReadAsync();

        Task<CrudStatus> UpdateAsync(AuthorUpdateDto author);
        
        Task<CrudStatus> DeleteAsync(int authorId);
    }
}