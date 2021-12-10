using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities {
    
    public class SubjectTag {
        
        // public SubjectTag(int id, string title) {
        //     Id = id;
        //     Title = title;
        // }

        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string? Title { get; set; }
    }
}