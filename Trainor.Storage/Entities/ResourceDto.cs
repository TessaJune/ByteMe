using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record ResourceDto(string? name, IEnumerable<string> authors) { }
    public record ResourceDetailsDto(string? name, string link, IEnumerable<string> authors, IEnumerable<SubjectTag> subjects, TypeTag type, DateTime date) { }
    public record ResourceCreateDto()
    {
        [StringLength(50)]
        public string? Name { get; init; }

        //Internet Explorer supports urls of up to length 2083, other popular browsers allow longer urls.
        const int MAX_URL_LENGTH = 2083;
        [StringLength(MAX_URL_LENGTH)]
        [Required]
        public string Link
        {
            get => Link;
            init => Link = Link ?? throw new NullReferenceException();
        }
        public IEnumerable<string>? Authors { get; init; }
        public TypeTag Type { get; init; }
        public IEnumerable<SubjectTag> Subjects { get; init; }
        public DateTime Date { get; init; }
    }
    public record ResourceUpdateDto()
    {
        public int Id { get; init; }
    }
}