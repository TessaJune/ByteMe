using System;
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
                    new User { Id = 1, GivenName = "Frida", LastName = "Roed", Email = "frir@itu.dk" },
                    new User { Id = 2, GivenName = "Oskar Emil", LastName = "Breindahl", Email = "osbr@itu.dk" },
                    new User { Id = 3, GivenName = "Simon", LastName = "Kristiansen", Email = "silk@itu.dk" },
                    new User { Id = 3, GivenName = "Freyja", LastName = "Weile", Email = "krwe@itu.dk" },
                    new User { Id = 3, GivenName = "Dagrún Eir", LastName = "Àsgeirsdóttir", Email = "daas@itu.dk" },
                    new User { Id = 3, GivenName = "Tessa June", LastName = "Strand", Email = "tejs@itu.dk" });

                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedResourceAsync(DataContext context, IAuthorRepository authorRepository, ISubjectTagRepository subjectTagRepository)
        {
            await context.Database.MigrateAsync();

            if (!await context.Resources.AnyAsync())
            {
                // Authors
                var martinKleppmann = new Author {Id = 5, GivenName = "Martin", LastName = "Kleppman" };
                var flaviuCristian = new Author {Id = 10, GivenName = "Flaviu", LastName = "Cristian" };
                var jamesLewis = new Author {Id = 15, GivenName = "James", LastName = "Lewis" };
                var martinFowler = new Author {Id = 20, GivenName = "Martin", LastName = "Fowler" };
                var josephHellerStein = new Author {Id = 25, GivenName = "Joseph", LastName = "Hellerstein" };
                var michaelStonebraker = new Author {Id = 30, GivenName = "Michael", LastName = "Stonebraker" };
                var jamesHamilton = new Author {Id = 35, GivenName = "James", LastName = "Hamilton" };
                var danielAbadi = new Author {Id = 40, GivenName = "Daniel", LastName = "Abadi" };
                var davidPine = new Author {Id = 45, GivenName = "David", LastName = "Pine" };
                var genevieveWarren = new Author {Id = 50, GivenName = "Genevieve", LastName = "Warren" };
                var martinaSeidl = new Author {Id = 55, GivenName = "Martina", LastName = "Seidl"};
                var marionScholzChristianHuemer = new Author {Id = 60, GivenName = "Marion Scholz Christian", LastName = "Huemer" };
                var gertiKappel = new Author {Id = 65, GivenName = "Gerti", LastName = "Kappel" };
                var steveSmith = new Author {Id = 70, GivenName = "Steve", LastName = "Smith" };
                var tomDykstra = new Author {Id = 75, GivenName = "Tom", LastName = "Dykstra" };

                // Creating subjects
                var cSharp = new SubjectTag{Id = 1, Title ="C#"};
                var java = new SubjectTag{Id = 2, Title = "Java"};
                var goLang = new SubjectTag{Id = 3, Title = "GoLang"};
                var SQL = new SubjectTag{Id = 4, Title = "SQL"};
                var HTML = new SubjectTag{Id = 5, Title = "HTML"};
                var CSS = new SubjectTag{Id = 6, Title = "CSS"};
                var distributedSystems = new SubjectTag{Id = 7, Title = "Distributed systems"};
                var databaseManagement  = new SubjectTag{Id = 8, Title = "Database management"};
                var unitTesting = new SubjectTag{Id = 9, Title = "Unit testing"};
                var dotnet = new SubjectTag{Id = 10, Title = ".NET"};
                var gitHub = new SubjectTag{Id = 11, Title = "GitHub"};
                var umlDiagrams = new SubjectTag{Id = 12, Title = "UML diagrams"};
                var softwareEngineering = new SubjectTag{Id = 13, Title = "Software engineeting"};
   
                // Resources
                context.Resources.AddRange( // Missing the date - should dates be "[Range(1900, 2100)]" ?
                    new Resource { Id = 2, Name = "The RAFT Consensus Algorithm", Link = "https://raft.github.io/", Authors = new[] {martinKleppmann}, Subjects = new[] {goLang, distributedSystems}, Type = TypeTag.DOCUMENT},
                    new Resource {Id = 4, Name = "Microservices", Link = "https://martinfowler.com/articles/microservices.html", Authors = new[] {martinFowler}, Subjects = new[] {goLang, distributedSystems}, Type = TypeTag.DOCUMENT},
                    new Resource { Id = 6, Name = "Probabilistic clock synchronization", Link = "https://www.cs.utexas.edu/users/lorenzo/corsi/cs380d/papers/Cristian.pdf", Authors = new[] {flaviuCristian}, Subjects = new[] {distributedSystems}, Type = TypeTag.PDF},
                    new Resource { Id = 8, Name = "Introduction to Operating Systems", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132582/introduction.pdf", Subjects = new[] {databaseManagement}, Type = TypeTag.PDF},
                    new Resource { Id = 10, Name = "Architecture of a Database System", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132585/fntdb07-architecture.pdf", Authors = new[] {josephHellerStein, michaelStonebraker, jamesHamilton}, Subjects = new[] {databaseManagement}, Type = TypeTag.PDF},
                    new Resource { Id = 12, Name = "Consistency Tradeoffs in Modern Distributed Database System Design", Link = "https://learnit.itu.dk/pluginfile.php/270772/course/section/132586/abadi.pacelc.computer2012.pdf", Authors = new[] {danielAbadi}, Subjects = new[] {databaseManagement}, Type = TypeTag.PDF},
                    new Resource { Id = 14, Name = "Unit testing C# in .NET Core using dotnet test and xUnit", Link = "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test", Authors = new[] {steveSmith, tomDykstra}, Subjects = new[] {unitTesting, dotnet, cSharp}, Type = TypeTag.ARTICLE},
                    new Resource { Id = 16, Name = "GitHub Actions and .NET", Link = "https://docs.microsoft.com/en-us/dotnet/devops/github-actions-overview", Authors = new[] {davidPine, genevieveWarren}, Subjects = new[] {gitHub, dotnet, cSharp}, Type = TypeTag.ARTICLE},
                    new Resource { Id = 18, Name = "An Introduction to Object-Oriented Modeling", Link = "https://link.springer.com/content/pdf/10.1007%2F978-3-319-12742-2.pdf", Authors = new[] {marionScholzChristianHuemer, martinaSeidl, gertiKappel}, Subjects = new[] {umlDiagrams, softwareEngineering}, Type = TypeTag.PDF}
                );

                await context.SaveChangesAsync();
            }
        }
    }
}