using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{

    public class SubjectTag
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }

        public IEnumerable<Resource>? Resources { get; set; } = new List<Resource>();
    }
}