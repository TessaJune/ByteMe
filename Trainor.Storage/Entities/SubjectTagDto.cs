using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record SubjectTagDetailsDto(int Id, string Title) { }
    public record SubjectTagCreateDto()
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; init; }
    }
    public record SubjectTagDto(int Id, string Title)
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Title { get; init; }
    }

    public record SubjectTagUpdateDto : SubjectTagCreateDto
    {
        public int Id { get; set; }
    }
}