using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Trainor.Storage
{
    public record ResourceDto(string? name, IEnumerable<string> authors) { }
    public record ResourceDetailsDto(string? name, string link, IEnumerable<string> authors, string type, DateTime date) { }
    public record ResourceCreateDto()
    {
        [StringLength(50)]
        public string? Name { get; init; }

        //Internet Explorer supports urls of up to length 2083, other popular browsers allow longer urls.
        const int MAX_URL_LENGTH = 2083;
        [StringLength(MAX_URL_LENGTH)]
        [Required]
        public string Link { get; init; }

        public IEnumerable<string>? Authors { get; init; }

    }
    public record ResourceUpdateDto()
    {
        public int Id { get; init; }
    }
}