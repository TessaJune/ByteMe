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

        public async Task<IReadOnlyCollection<ResourceDto>> SearchAllAsync()
        {
            var asyncResult = await _repo.ReadAsync();
            return asyncResult.Item2;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> QueryRepoFilteredAsync(IEnumerable<string> filters)
        {
            var subjectTags = Enum.GetValues(typeof(SubjectTag));
            var typeTags = Enum.GetValues(typeof(TypeTag));
            var subjectTagsSearchList = new List<SubjectTag>();
            var typeTagsSearchList = new List<TypeTag>();

            foreach (var filter in filters)
            {
                foreach (TypeTag typeTag in typeTags)
                {
                    if (filter.ToLower().Equals(typeTag.ToString().ToLower()))
                    {
                        typeTagsSearchList.Add(typeTag);
                    }
                }

                foreach (SubjectTag subjectTag in subjectTags)
                {
                    if (filter.ToLower().Equals(subjectTag.ToString().ToLower()))
                    {
                        subjectTagsSearchList.Add(subjectTag);
                    }
                }
            }

            (CrudStatus, IReadOnlyCollection<ResourceDto>) asyncResult = (CrudStatus.Ok, null);

            if (typeTags.Length != 0 && subjectTags.Length != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(subjectTags, typeTags);
            }
            else if (subjectTags.Length != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(subjectTags);
            }
            else if (typeTags.Length != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(typeTags);
            }
            
            return asyncResult.Item2;
        }
        
        public async Task<IReadOnlyCollection<ResourceDto>> QueryRepoKeywordsAsync(IEnumerable<string> keywords)
        {
            var asyncResult = _repo.ReadKeywordsAsync(keywords);
            return asyncResult.Item2;
        }
    }
}