using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage;
using Trainor.Storage.Entities;
using Xunit;
using static Trainor.Storage.Entities.SubjectTag;
using static Trainor.Storage.Entities.TypeTag;

namespace Trainor.Storage.Tests
{
    public class ResourceRepositoryTests : IDisposable
    {
        private readonly IDataContext _context;
        private readonly ResourceRepository _repository;

        public ResourceRepositoryTests()
        {
            // Creating database that tests can communicate with
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlite(connection);

            var dataContext = new DataContext(builder.Options);
            dataContext.Database.EnsureCreated();

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
            dataContext.Resources.AddRange( // Missing the date - should dates be "[Range(1900, 2100)]" ?
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

            dataContext.SaveChanges();

            _context = dataContext;
            _repository = new ResourceRepository(_context);
        }

        [Fact]
        public async Task ReadFromKeywordsAsync_given_microservices_random_case_has_1_resource_and_correct_id_and_correct_link()
        {
            var resources = await _repository.ReadFromKeywordsAsync(new[] { "MiCRoSERVices" });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 1, "count not 1");
            Assert.Collection(resources.Item2,
                 resource => Assert.True(resource.Id == 2 && resource.Link == "https://martinfowler.com/articles/microservices.html")
            );
        }

        [Fact]
        public async Task ReadFromKeywordsAsync_given_micro_has_two_resources_with_microsoft_link_and_one_resource_with_microservice_name()
        {
            var resources = await _repository.ReadFromKeywordsAsync(new[] { "micro" });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 3, "count not 3");
            Assert.Collection(resources.Item2,
                 resource => Assert.True(resource.Id == 2 && resource.Link == "https://martinfowler.com/articles/microservices.html"),
                 resource => Assert.True(resource.Id == 7 && resource.Link == "https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test"),
                 resource => Assert.True(resource.Id == 8 && resource.Link == "https://docs.microsoft.com/en-us/dotnet/devops/github-actions-overview")

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 1, "count not 1");
            Assert.Collection(resources.Item2,
                 resource => Assert.True(resource.Id == 2 && resource.Link == "https://martinfowler.com/articles/microservices.html")
            );
        }

        [Fact]
        public async Task ReadFromKeywordsAsync_given_microservices_and_raft_has_two_resources_with_names_and_ids()
        {
            var resources = await _repository.ReadFromKeywordsAsync(new[] { "microservices", "raft" });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 2, "count not 2");
            Assert.Collection(resources.Item2,
                resource => Assert.True(resource.Id == 1 && resource.Link == "https://raft.github.io/"),
                resource => Assert.True(resource.Id == 2 && resource.Link == "https://martinfowler.com/articles/microservices.html")
            );
        }

        [Fact]
        public async Task ReadFromKeywordsAsync_given_gibberish_has_no_resources()
        {
            var resources = await _repository.ReadFromKeywordsAsync(new[] { "godsjjigodsfsaiofoaig" });

            Assert.True(resources.Item1 == CrudStatus.NotFound, "status not notfound");
            Assert.True(resources.Item2 == null, "result not null");
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_subjectTag_GOLANG_has_microservices_and_raft()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { GOLANG });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 2, "count not 2");
            Assert.Collection(resources.Item2,
                resource => Assert.True(resource.Id == 1 && resource.Link == "https://raft.github.io/"),
                resource => Assert.True(resource.Id == 2 && resource.Link == "https://martinfowler.com/articles/microservices.html")
            );
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_SubjectTag_CSHARP_has_no_resources()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { CSHARP });

            Assert.True(resources.Item1 == CrudStatus.NotFound, "status not notfound");
            Assert.True(resources.Item2 == null);
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_TypeTag_PDF_has_5_resources()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { PDF });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 5, "count not 5");
            Assert.Collection(resources.Item2,
                resource => Assert.True(resource.Id == 3 && resource.Link == "https://www.cs.utexas.edu/users/lorenzo/corsi/cs380d/papers/Cristian.pdf"),
                resource => Assert.True(resource.Id == 4 && resource.Link == "https://learnit.itu.dk/pluginfile.php/270772/course/section/132582/introduction.pdf"),
                resource => Assert.True(resource.Id == 5 && resource.Link == "https://learnit.itu.dk/pluginfile.php/270772/course/section/132585/fntdb07-architecture.pdf"),
                resource => Assert.True(resource.Id == 6 && resource.Link == "https://learnit.itu.dk/pluginfile.php/270772/course/section/132586/abadi.pacelc.computer2012.pdf"),
                resource => Assert.True(resource.Id == 9 && resource.Link == "https://link.springer.com/content/pdf/10.1007%2F978-3-319-12742-2.pdf")
            );
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_TypeTag_VIDEO_has_no_resources()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { VIDEO });

            Assert.True(resources.Item1 == CrudStatus.NotFound, "status not notfound");
            Assert.True(resources.Item2 == null);
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_TypeTag_PDF_and_SubjectTag_UML_has_introtoood()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { PDF }, new[] { UML });

            Assert.True(resources.Item1 == CrudStatus.Ok, "status not ok");
            Assert.True(resources.Item2.Count == 1, "count not 1");
            Assert.Collection(resources.Item2,
                resource => Assert.True(resource.Id == 9 && resource.Link == "https://link.springer.com/content/pdf/10.1007%2F978-3-319-12742-2.pdf")
            );
        }

        [Fact]
        public async Task ReadFromFiltersAsync_given_TypeTag_VIDEO_and_SubjectTag_UML_has_no_resources()
        {
            var resources = await _repository.ReadFromFiltersAsync(new[] { VIDEO }, new[] { UML });

            Assert.True(resources.Item1 == CrudStatus.NotFound, "status not notfound");
            Assert.True(resources.Item2 == null);
        }

        // DO NOT EDIT THIS. Code from Rasmus  
        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}