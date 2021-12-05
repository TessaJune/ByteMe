using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public record UserDetailsDto
    {
    }
    public record UserCreateDto()
    {
        [StringLength(50)]
        public string? GivenName { get; init; }

        [StringLength(50)]
        public string? LastName { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
    }
    public record UserDto()
    {
        [StringLength(50)]
        public string? GivenName { get; init; }

        [StringLength(50)]
        public string? LastName { get; init; }

        [EmailAddress]
        public string? Email { get; init; }
    }
}