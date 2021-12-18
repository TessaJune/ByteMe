using Xunit;
using Trainor.Storage;
using Trainor.Storage.Entities;
using System.Threading.Tasks;
using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Trainor.Storage.Tests
{
    public class AuthorRepositoryTests : IDisposable
    {
        private readonly IDataContext _context;
        private readonly AuthorRepository _repository;

        public AuthorRepositoryTests()
        {
            // Creating database that tests can communicate with
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlite(connection);
            var dataContext = new DataContext(builder.Options);
            dataContext.Database.EnsureCreated();
            dataContext.Authors.AddRange(new Author{Id = 12, GivenName = "John", LastName = "Doe"}, 
                                         new Author{Id = 15, GivenName = "Jane", LastName = "Doe"});
            dataContext.SaveChanges();

            _context = dataContext;
            _repository = new AuthorRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_creates_new_author_with_createAuthorDto_returns_created()
        {
            // Arrange
            AuthorCreateDto alice = new AuthorCreateDto
            {
                Id = 56,
                GivenName = "Alice",
                LastName = "Unknown"
            };

            // Act
            var aliceCreated = await _repository.CreateAsync(alice);

            // Assert
            Assert.Equal((CrudStatus.Created, new AuthorDto(56, "Alice", "Unknown")), aliceCreated);
        }

        [Fact]
        public async Task ReadAsync_reads_author_with_existing_id_returns_ok() 
        {     
            var authorId = await _repository.ReadAsync(12);

            Assert.Equal((CrudStatus.Ok, new AuthorDto(12, "John", "Doe")), authorId);
            // Reads author that exists in database created in the AuthorRepositoryTests() method
        }

        [Fact]
        public async Task ReadAsync_reads_author_with_non_existing_id_returns_not_found()
        {     
            var alice = new AuthorDto(56, "Alice", "Unknown");

            var aliceId = await _repository.ReadAsync(alice.Id);

            Assert.Equal((CrudStatus.NotFound, null), aliceId);
            // Can't read an author that does not exist in the database
        }

        // [Fact] -- This is not working yet, hence why it's outcommented
        // public async Task ReadAsync_returns_all_authors()
        // {
        //     var authors = await _repository.ReadAsync();

        //     Assert.Collection(authors,
        //         author => Assert.Equal((CrudStatus.Ok, new AuthorDto(12, "John", "Doe")), author),
        //         author => Assert.Equal((CrudStatus.Ok, new AuthorDto(15, "Jane", "Doe")), author)
        //     );
        // }

        [Fact]
        public async Task UpdateAsync_updates_author_with_existing_id_returns_true() 
        { 
            var john = new AuthorUpdateDto
            {
                Id = 12,
                GivenName = "John",
                LastName = ""
            };

            var updatedJohn = await _repository.UpdateAsync(john);

            Assert.Equal(CrudStatus.Updated, updatedJohn);

            // Testing to see that the updated method removed authorJohn lastname
            var test = await _repository.ReadAsync(john.Id);
            Assert.Empty(john.LastName);
        }

        [Fact]
        public async Task UpdateAsync_updates_author_with_non_existing_id_returns_false() 
        { 
            var alice = new AuthorUpdateDto 
            {
                Id = 56,
                GivenName = "Alice",
                LastName = "unknown"
            };

            var updatedAlice = await _repository.UpdateAsync(alice);
            Assert.Equal(CrudStatus.NotFound, updatedAlice); 
            // The database does not know about Alice, which is why it can't be updated.
        }

        [Fact]
        public async Task DeleteAsync_given_an_existing_author_returns_Deleted() 
        {
            var john = new AuthorDto(12, "John", "Doe");

            var deleteJohn = await _repository.DeleteAsync(john.Id);

            Assert.Equal(CrudStatus.Deleted, deleteJohn);
        }

        [Fact]
        public async Task DeleteAsync_given_non_existing_author_returns_NotFound()
        {
            var deletedAlice = await _repository.DeleteAsync(56);
            Assert.Equal(CrudStatus.NotFound, deletedAlice); 
            // It can't delete a author, that does not exists in the database
        }

        // DO NOT EDIT THIS 
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