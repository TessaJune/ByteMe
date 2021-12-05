using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public class Resource
    {
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string Link { get; set; }
        public IEnumerable<string>? Authors { get; set; }
        public TypeTag Type { get; set; }
        public IEnumerable<SubjectTag>? Subjects { get; set; }
        public DateTime Date { get; set; }
    }
}