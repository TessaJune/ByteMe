using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Trainor.Storage.Entities;
using static Trainor.Storage.Entities.SubjectTag;
using static Trainor.Storage.Entities.TypeTag;

namespace Trainor.Storage
{

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

                await SeedUserAsync(context, userRepository);
                await SeedResourceAsync(context, authorRepository);
            }
            return host;
        }

        private static async Task SeedUserAsync(DataContext context, IUserRepository userRepository)
        {
            await context.Database.MigrateAsync();

            if (!await context.Users.AnyAsync())
            {
                context.Users.AddRange(
                    new User { Id = 1, GivenName = "Frida", LastName = "Roed", Email = "frir@itu.dk" },
                    new User { Id = 2, GivenName = "Oskar Emil", LastName = "Breindahl", Email = "osbr@itu.dk" },
                    new User { Id = 3, GivenName = "Simon", LastName = "Kristiansen", Email = "silk@itu.dk" },
                    new User { Id = 4, GivenName = "Freyja", LastName = "Weile", Email = "krwe@itu.dk" },
                    new User { Id = 5, GivenName = "Dagrún Eir", LastName = "Àsgeirsdóttir", Email = "daas@itu.dk" },
                    new User { Id = 6, GivenName = "Tessa June", LastName = "Strand", Email = "tejs@itu.dk" });

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedResourceAsync(DataContext context, IAuthorRepository authorRepository)
        {
            await context.Database.MigrateAsync();

            if (!await context.Resources.AnyAsync())
            {
                // Authors
                var martinKleppmann = new Author { Id = 5, GivenName = "Martin", LastName = "Kleppman" };
                var flaviuCristian = new Author { Id = 10, GivenName = "Flaviu", LastName = "Cristian" };
                var jamesLewis = new Author { Id = 15, GivenName = "James", LastName = "Lewis" };
                var martinFowler = new Author { Id = 20, GivenName = "Martin", LastName = "Fowler" };
                var josephHellerStein = new Author { Id = 25, GivenName = "Joseph", LastName = "Hellerstein" };
                var michaelStonebraker = new Author { Id = 30, GivenName = "Michael", LastName = "Stonebraker" };
                var jamesHamilton = new Author { Id = 35, GivenName = "James", LastName = "Hamilton" };
                var danielAbadi = new Author { Id = 40, GivenName = "Daniel", LastName = "Abadi" };
                var davidPine = new Author { Id = 45, GivenName = "David", LastName = "Pine" };
                var genevieveWarren = new Author { Id = 50, GivenName = "Genevieve", LastName = "Warren" };
                var martinaSeidl = new Author { Id = 55, GivenName = "Martina", LastName = "Seidl" };
                var marionScholzChristianHuemer = new Author { Id = 60, GivenName = "Marion Scholz Christian", LastName = "Huemer" };
                var gertiKappel = new Author { Id = 65, GivenName = "Gerti", LastName = "Kappel" };
                var steveSmith = new Author { Id = 70, GivenName = "Steve", LastName = "Smith" };
                var tomDykstra = new Author { Id = 75, GivenName = "Tom", LastName = "Dykstra" };

                // Resources
                context.Resources.AddRange( // Missing the date - should dates be "[Range(1900, 2100)]" ?
                    new Resource { Id = 1, Name = "The RAFT Consensus Algorithm", Link = "https://raft.github.io/", Authors = new List<Author> { martinKleppmann }, Subject = GOLANG, Type = TypeTag.DOCUMENT },
                    new Resource { Id = 2, Name = "Microservices", Link = "https://martinfowler.com/articles/microservices.html", Authors = new List<Author> { martinFowler }, Subject = GOLANG, Type = TypeTag.DOCUMENT },
                    new Resource { Id = 3, Name = "Probabilistic clock synchronization", Link = "https://www.cs.utexas.edu/users/lorenzo/corsi/cs380d/papers/Cristian.pdf", Authors = new List<Author> { flaviuCristian }, Subject = DISTRIBUTED_SYSTEMS, Type = TypeTag.PDF },
                    new Resource { Id = 4, Name = "Introduction to Operating Systems", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132582/introduction.pdf", Subject = DATABASE_MANAGEMENT, Type = TypeTag.PDF },
                    new Resource { Id = 5, Name = "Architecture of a Database System", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132585/fntdb07-architecture.pdf", Authors = new List<Author> { josephHellerStein, michaelStonebraker, jamesHamilton }, Subject = DATABASE_MANAGEMENT, Type = TypeTag.PDF },
                    new Resource { Id = 6, Name = "Consistency Tradeoffs in Modern Distributed Database System Design", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132586/abadi.pacelc.computer2012.pdf", Authors = new List<Author> { danielAbadi }, Subject = DATABASE_MANAGEMENT, Type = TypeTag.PDF },
                    new Resource { Id = 7, Name = "Unit testing C# in .NET Core using dotnet test and xUnit", Link = "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test", Authors = new List<Author> { steveSmith, tomDykstra }, Subject = TESTING, Type = TypeTag.ARTICLE },
                    new Resource { Id = 8, Name = "GitHub Actions and .NET", Link = "https://docs.microsoft.com/en-us/dotnet/devops/github-actions-overview", Authors = new List<Author> { davidPine, genevieveWarren }, Subject = GIT, Type = TypeTag.ARTICLE },
                    new Resource { Id = 9, Name = "An Introduction to Object-Oriented Modeling", Link = "https://link.springer.com/content/pdf/10.1007%2F978-3-319-12742-2.pdf", Authors = new List<Author> { marionScholzChristianHuemer, martinaSeidl, gertiKappel }, Subject = UML, Type = TypeTag.PDF }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}

