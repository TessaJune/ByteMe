using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainor.Storage.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string Link
        {
            get => Link;
            set => Link = Link ?? throw new NullReferenceException();
        }
        
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<SubjectTag>? Subjects { get; set; }
        public TypeTag Type { get; set; }
        public DateTime Date { get; set; }
    }
}