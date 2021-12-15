/*using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trainor.Storage.Entities;

namespace Trainor.Storage {

    public static class SeedExtensions
    {
        public static async Task<IHost> SeedAsync(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var resourceRepository = scope.ServiceProvider.GetRequiredService<IResourceRepository>();
                var authorRepository = scope.ServiceProvider.GetRequiredService<IAuthorRepository>();
                var subjectTagRepository = scope.ServiceProvider.GetRequiredService<ISubjectTagRepository>();

                await SeedResourceAsync(context, authorRepository, subjectTagRepository);
                await SeedUserAsync(context, userRepository);
            }
            return host;
        }

        private static async Task SeedUserAsync(DataContext context, IUserRepository userRepository)
        {
            await context.Database.MigrateAsync();

            if (!await context.Users.AnyAsync())
            {
                context.Users.AddRange(
                    new User { Id = 1, GivenName = "Frida", LastName = "Roed", Email = "frir@itu.dk"},
                    new User { Id = 2, GivenName = "Oskar", LastName = "Breindahl", Email = "osbr@itu.dk"},
                    new User { Id = 3, GivenName = "Simon", LastName = "Kristiansen", Email = "silk@itu.dk"}
                );

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedResourceAsync(DataContext context, IAuthorRepository authorRepository, ISubjectTagRepository subjectTagRepository)
        {
            await context.Database.MigrateAsync();

            if (!await context.Resources.AnyAsync())
            {
                // Creating authors
                var Paolo = new AuthorDetailsDto(1, "Paolo", "Tell");
                var Rasmus = new AuthorDetailsDto(2, "Rasmus", "Lystrøm");
                var UITeacher = new AuthorDetailsDto(3, "Some", "Teacher");

                // Creating subjects
                var CSharp = new SubjectTagDetailsDto(1, "C#");
                var Java = new SubjectTagDetailsDto(2, "Java");
                var GoLang = new SubjectTagDetailsDto(3, "GoLang");
                var SQL = new SubjectTagDetailsDto(4, "SQL");
                var HTML = new SubjectTagDetailsDto(5, "HTML");
                var CSS = new SubjectTagDetailsDto(2, "CSS");

                // context.Resources.AddRange( // Missing link + name
                //     new Resource { Id = 1, Name = "Software engineering", Link = "", Authors = new[] {Paolo}, Subjects = new [] {CSharp}, Types = TypeTag.PICTURE},
                //     new Resource { Id = 2, Name = "C# is the best", Link = "", Authors = new[] {Rasmus}, Subjects = new[] {CSharp}, Types = TypeTag.VIDEO, Date = System.DateTime.Now},
                //     new Resource { Id = 3, Name = "How to .. div", Link = "", Authors = new[] {UITeacher}, Subjects = new[] {HTML, CSS}, Types = TypeTag.DOCUMENT}
                // );

                await context.SaveChangesAsync();
            }
        }
    }
}*/
