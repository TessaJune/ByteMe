using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record ResourceDto(int id, string? name, string? link, IEnumerable<AuthorDto> authors, IEnumerable<SubjectTag>? subjects, TypeTag types, DateTime? date) { }
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
    
        public IEnumerable<AuthorDto> Authors { get; init; }
        public IEnumerable<SubjectTag>? Subjects { get; init; }
        public TypeTag Type { get; set; }
        public DateTime Date { get; init; }
    }
    public record ResourceUpdateDto : ResourceCreateDto
    {
        public int Id { get; init; }
    }
}