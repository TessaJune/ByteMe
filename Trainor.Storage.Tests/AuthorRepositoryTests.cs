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
            var context = new DataContext(builder.Options);
            context.Database.EnsureCreated();
            context.SaveChanges();

            _context = context;
            _repository = new AuthorRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_creates_new_author_with_createAuthorDto()
        {
            // Arrange
            AuthorCreateDto author = new AuthorCreateDto
            {
                Id = 1,
                GivenName = "Paolo",
                LastName = "Tell"
            };

            // Act
            var authorCreated = await _repository.CreateAsync(author);

            // Assert
            Assert.Equal((CrudStatus.Created, new AuthorDto(1, "Paolo", "Tell")), authorCreated);
        }

        // [Fact]
        // public async Task ReadAsync_reads_author_with_given_id_returns_true() // Return Status and xDto, input xId 
        // {     
        //     var authorId = await _repository.ReadAsync(12);

        //     Assert.Equal((CrudStatus.Ok, new AuthorDto(12, "John", "Doe")), authorId);
        // } THIS TEST IS NOT PASSING YET

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
/* 
    Test repositories:          |        Methods that should be tested
    - ResourceRepository        |        
    - UserRepository            |        - ReadAsync()     -- Return Status and xDto, input xId 
    - SubjectTagRepository      |        - ReadAsync()     -- Return Status and collection of xDto
    - AuthorRepository          |        - UpdateAsync()   -- Return Status, input xId
                                |        - DeleteAsync()   -- Return Status, input xId
*/