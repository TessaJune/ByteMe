using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public class User
    {
        [StringLength(50)]
        public string? GivenName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }
    }
}