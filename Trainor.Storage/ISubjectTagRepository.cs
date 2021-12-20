using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;
namespace Trainor.Storage
{
    public interface ISubjectTagRepository
    {
        Task<(CrudStatus, SubjectTagDto)> CreateAsync(SubjectTagCreateDto author);

        Task<(CrudStatus, SubjectTagDto)> ReadAsync(int SubjectTagId);

        Task<(CrudStatus, IReadOnlyCollection<SubjectTagDto>)> ReadAsync();

        Task<CrudStatus> UpdateAsync(SubjectTagUpdateDto SubjectTag);
        
        Task<CrudStatus> DeleteAsync(int SubjectTagId);
    }
}