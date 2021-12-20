using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities {
    
    public class Author {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string GivenName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }
    }
}