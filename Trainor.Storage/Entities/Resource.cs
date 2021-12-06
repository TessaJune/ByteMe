using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }

        [Required]
        [Url]
        public string Link
        {
            get => Link;
            set => Link = Link ?? throw new NullReferenceException();
        }
        public IEnumerable<string>? Authors { get; set; }
        public TypeTag Type { get; set; }
        public IEnumerable<SubjectTag>? Subjects { get; set; }
        public DateTime Date { get; set; }
    }
}