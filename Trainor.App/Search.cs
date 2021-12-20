using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trainor.Storage;
using Trainor.Storage.Entities;

namespace Trainor.App
{
    public class Search : ISearch
    {
        private IResourceRepository _repo;
        
        public Search(IResourceRepository repo)
        {
            _repo = repo;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> SearchAll()
        {
            var asyncResult = await _repo.ReadAsync();
            return asyncResult.Item2;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> SearchByFilter(string filter)
        {
            var subjectTags = Enum.GetValues(typeof(SubjectTag));
            var typeTags = Enum.GetValues(typeof(TypeTag));
            
            foreach (TypeTag typeTag in typeTags)
            {
                if (filter.ToLower().Equals(typeTag.ToString().ToLower()))
                {
                    TypeTag searchFilter = typeTag;
                    var asyncResult = await _repo.ReadFromFilters(searchFilter);
                    return asyncResult.Item2;
                }
            }
            foreach (SubjectTag subjectTag in subjectTags)
            {
                if (filter.ToLower().Equals(subjectTag.ToString().ToLower()))
                {
                    SubjectTag[] searchFilter = { subjectTag };
                    var asyncResult = await _repo.ReadFromFilters(searchFilter);
                    return asyncResult.Item2;
                }
            }
            return null;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> SearchByFilters(IEnumerable<string> filters)
        {
            var subjectTags = Enum.GetValues(typeof(SubjectTag));
            var typeTags = Enum.GetValues(typeof(TypeTag));
            foreach (var filter in filters) 
            {
                foreach (TypeTag typeTag in typeTags)
                {
                    if (filter.ToLower().Equals(typeTag.ToString().ToLower()))
                    {
                        return await SearchByFilters(typeTag, filters);
                    }
                }
            }

            List<SubjectTag> searchFilters = new List<SubjectTag>();
            foreach (var filter in filters)
            {
                foreach (SubjectTag subjectTag in subjectTags)
                {
                    if (filter.ToLower().Equals(subjectTag.ToString().ToLower()))
                    {
                        searchFilters.Add(subjectTag);
                    }
                } 
            }
            var asyncResult = await _repo.ReadFromFilters(searchFilters);
            return asyncResult.Item2;
        }
        
        public async Task<IReadOnlyCollection<ResourceDto>> SearchByFilters(TypeTag typeFilter, IEnumerable<string> filters)
        {
            var subjectTags = Enum.GetValues(typeof(SubjectTag));
            List<SubjectTag> searchFilters = new List<SubjectTag>();
            foreach (var filter in filters)
            {
                foreach (SubjectTag subjectTag in subjectTags)
                {
                    if (filter.ToLower().Equals(subjectTag.ToString().ToLower()))
                    {
                        searchFilters.Add(subjectTag);
                    }
                } 
            }
            var asyncResult = await _repo.ReadFromFilters(typeFilter, searchFilters);
            return asyncResult.Item2;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> SearchByYear(int year)
        {
            throw new NotImplementedException();
        }
    }
}