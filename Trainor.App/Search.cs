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

        public async Task<IReadOnlyCollection<ResourceDetailsDto>> SearchByType(string type)
        {
            var typeTags = Enum.GetValues(typeof(TypeTag));
            
            foreach (TypeTag typeTag in typeTags)
            {
                if (type.Equals(typeTag.ToString()))
                {
                    var typeToSearch = typeTag;
                    var asyncResult = await _repo.ReadFromFilters(typeToSearch);
                    return asyncResult.Item2;
                }
            }
            return null;
        }

        public async Task<IReadOnlyCollection<ResourceDetailsDto>> SearchBySubject(IEnumerable<string> subjects)
        {
            var subjectTags = Enum.GetValues(typeof(SubjectTag));
            var subjectsToSearch = new List<string>();

            foreach (var subjectTag in subjectTags)
            {
                foreach (var subject in subjects)
                {
                    subjectsToSearch.Add(subject);
                }
            }

            if (subjectsToSearch.Count != 0)
            {
                SubjectTag[] subjectTagsToSearch = new SubjectTag[subjectsToSearch.Count];
                var counter = 0;
                foreach (SubjectTag subjectTag in subjectTags)
                {
                    foreach (var subject in subjectsToSearch)
                    {
                        subjectTagsToSearch[counter] = subjectTag;
                        counter++;
                    }
                }
                var asyncResult = 
                    await _repo.ReadFromFilters(subjectTagsToSearch);
                return asyncResult.Item2;
            }
            return null;
        }

        public async Task<IReadOnlyCollection<ResourceDetailsDto>> SearchByYear(int year)
        {
            throw new NotImplementedException();
        }

    }
}