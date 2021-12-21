using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public static class AuthorExtensions
    {
        public static AuthorDto AsDto(this Author author)
        {
            return new AuthorDto
            (
                author.Id,
                author.GivenName,
                author.LastName
            );
        }

        public static IEnumerable<AuthorDto> AsDto(this IEnumerable<Author> authors)
        {
            foreach (var author in authors)
            {
                yield return author.AsDto();
            }
        }
    }
}