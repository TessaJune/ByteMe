using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trainor.Storage.Entities
{
    public class Resource
    {
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }

        private string _link;
        [Required]
        [Url]
        public string Link
        {
            get => _link;
            set => _link = value ?? throw new NullReferenceException();
        }

        public ICollection<Author> Authors { get; set; } = new HashSet<Author>();
        public SubjectTag Subject { get; set; }
        public TypeTag Type { get; set; }
        public DateTime Date { get; set; }
    }
}