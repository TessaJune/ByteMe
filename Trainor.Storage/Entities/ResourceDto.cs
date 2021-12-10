using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record ResourceDto(string? name, ISet<string>? authors) { }
    public record ResourceDetailsDto(int id, string? name, string? link, ISet<string> authors, /*IEnumerable<string>? authors,*/ ISet<SubjectTag> Subjects, TypeTag Types/*IEnumerable<SubjectTag>? subjects*/, DateTime? date) { }
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
        
        // public IEnumerable<string>? Authors { get; init; }
        public ISet<string> Authors { get; set; }
        public TypeTag Type { get; init; }
        public ISet<SubjectTag> Subjects { get; set; }
        // public IEnumerable<SubjectTag>? Subjects { get; init; }
        public TypeTag Types { get; set; }
        public DateTime Date { get; init; }
    }
    public record ResourceUpdateDto : ResourceCreateDto
    {
        public int Id { get; init; }
    }
}