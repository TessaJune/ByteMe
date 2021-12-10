using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record ResourceDto(string? name, IEnumerable<Author>? authors) { }
    public record ResourceDetailsDto(int id, string? name, string? link, IEnumerable<Author> authors, IEnumerable<SubjectTag>? subjects, TypeTag types, DateTime? date) { }
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
    
        public IEnumerable<Author> Authors { get; init; }
        public IEnumerable<SubjectTag>? Subjects { get; init; }
        public TypeTag Types { get; set; }
        public DateTime Date { get; init; }
    }
    public record ResourceUpdateDto : ResourceCreateDto
    {
        public int Id { get; init; }
    }
}