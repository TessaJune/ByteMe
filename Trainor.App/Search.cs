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
            SubjectTag[] subjectTags = (SubjectTag[]) Enum.GetValues(typeof(SubjectTag));
            TypeTag[] typeTags = (TypeTag[]) Enum.GetValues(typeof(TypeTag));
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

            if (typeTagsSearchList.Count != 0 && subjectTagsSearchList.Count != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(typeTagsSearchList, subjectTagsSearchList);
            }
            else if (subjectTags.Length != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(subjectTagsSearchList);
            }
            else if (typeTags.Length != 0)
            {
                asyncResult = await _repo.ReadFromFiltersAsync(typeTagsSearchList);
            }

            return asyncResult.Item2;
        }

        public async Task<IReadOnlyCollection<ResourceDto>> QueryRepoKeywordsAsync(IEnumerable<string> keywords)
        {
            var asyncResult = await _repo.ReadFromKeywordsAsync(keywords);
            return asyncResult.Item2;
        }
    }
}
