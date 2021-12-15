using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public interface IResourceRepository
    {
        Task<(CrudStatus, ResourceDetailsDto)> CreateAsync(ResourceCreateDto resource);
        Task<(CrudStatus, IReadOnlyCollection<ResourceDto>)> ReadAsync();
        Task<(CrudStatus, ResourceDto?)> ReadAsync(int resourceId);
        Task<(CrudStatus, ResourceDetailsDto?)> ReadDetailsAsync(int resourceId);
        Task<CrudStatus> UpdateAsync(ResourceUpdateDto resource);
        Task<CrudStatus> DeleteAsync(int resourceId);
        Task<(CrudStatus, IReadOnlyCollection<ResourceDetailsDto?>)> ReadFromKeyword(string keyword);
        Task<(CrudStatus, IReadOnlyCollection<ResourceDetailsDto?>)> ReadFromFilters(TypeTag filterTags);
        Task<(CrudStatus, IReadOnlyCollection<ResourceDetailsDto?>)> ReadFromFilters(IEnumerable<SubjectTag> filterTags);
        Task<(CrudStatus, IReadOnlyCollection<ResourceDetailsDto?>)> ReadFromFilters(TypeTag typeFilter, IEnumerable<SubjectTag> subjectFilter);

        /*
        TypeTag is a temporary solution, unsure how to get around making 3 methods for each Tag for filters.
        3 Would be: Method for TypeTag, Method for Subject Tag, Method for both
        */
    }
}