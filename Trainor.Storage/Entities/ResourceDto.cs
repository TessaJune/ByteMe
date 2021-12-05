using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record ResourceDto(string? name, IEnumerable<string> authors) { }
    public record ResourceDetailsDto(string? name, string link, IEnumerable<string> authors, TypeTag type, IEnumerable<SubjectTag> subjects, DateTime date) { }
    public record ResourceCreateDto
    {
        [StringLength(50)]
        public string? Name { get; init; }

        [Required]
        [Url]
        public string Link
        {
            get => Link;
            init => Link = Link ?? throw new NullReferenceException();
        }
        public IEnumerable<string>? Authors { get; init; }
        public TypeTag Type { get; init; }
        public IEnumerable<SubjectTag>? Subjects { get; init; }
        public DateTime Date { get; init; }
    }
    public record ResourceUpdateDto() : ResourceCreateDto
    {
        public int Id { get; init; }
    }
}