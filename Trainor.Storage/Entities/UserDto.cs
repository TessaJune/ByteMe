using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record UserDetailsDto(int Id, string GivenName, string LastName, string Email) { }
    public record UserCreateDto()
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? GivenName { get; init; }

        [StringLength(50)]
        public string? LastName { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
    }
    public record UserDto(int id, string GivenName, string LastName)
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? GivenName { get; init; }

        [StringLength(50)]
        public string? LastName { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
    }

    public record UserUpdateDto : UserCreateDto
    {
        public int Id { get; set; }
    }
}
