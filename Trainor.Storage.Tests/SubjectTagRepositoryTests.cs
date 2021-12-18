using Xunit;
using Trainor.Storage;
using Trainor.Storage.Entities;
using System.Threading.Tasks;
using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Trainor.Storage.Tests
{
    public class SubjectTagRepositoryTests : IDisposable
    {
        private readonly IDataContext _context;
        private readonly SubjectTagRepository _repository;

        public SubjectTagRepositoryTests()
        {
            // Creating database that tests can communicate with
            var connection = new SqliteConnection("Filename=:memory:");
            connection.Open();
            var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlite(connection);
            var dataContext = new DataContext(builder.Options);
            dataContext.Database.EnsureCreated();
            dataContext.SubjectTags.AddRange(new SubjectTag{Id = 1, Title = "C#"}, 
                                             new SubjectTag{Id = 2, Title = "HTML"},
                                             new SubjectTag{Id = 3, Title = "CSS"});
            dataContext.SaveChanges();

            _context = dataContext;
            _repository = new SubjectTagRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_creates_new_subjectTag_with_createSubjectTagDto_returns_created()
        {
            // Arrange
            var goLang = new SubjectTagCreateDto
            {
                Id = 10,
                Title = "GoLang"
            };

            // Act
            var goLangCreated = await _repository.CreateAsync(goLang);

            // Assert
            Assert.Equal((CrudStatus.Created, new SubjectTagDto(10, "GoLang")), goLangCreated);
        }

        [Fact]
        public async Task ReadAsync_reads_subjectTag_with_existing_id_returns_ok() 
        {     
            var subjectTagId = await _repository.ReadAsync(1);

            Assert.Equal((CrudStatus.Ok, new SubjectTagDto(1, "C#")), subjectTagId);
            // Reads subjectTag that exists in database created in the SubjectTagRepositoryTests() method
        }

        [Fact]
        public async Task ReadAsync_reads_subjectTag_with_non_existing_id_returns_notFound()
        {     
            var goLang = new SubjectTagDto(10, "GoLang");

            var goLangId = await _repository.ReadAsync(goLang.Id);

            Assert.Equal((CrudStatus.NotFound, null), goLangId);
            // Can't read a subjectTag that does not exist in the database
        }

        [Fact]
        public async Task UpdateAsync_updates_subjectTag_with_existing_id_returns_true() 
        { 
            var csharp = new SubjectTagUpdateDto
            {
                Id = 1,
                Title = "",
            };

            var cSharpUpdated = await _repository.UpdateAsync(csharp);

            Assert.Equal(CrudStatus.Updated, cSharpUpdated);

            // Testing to see that the updated method removed csharp title
            var test = await _repository.ReadAsync(csharp.Id);
            Assert.Empty(csharp.Title);
        }

        [Fact]
        public async Task UpdateAsync_updates_subjectTag_with_non_existing_id_returns_notFound() 
        { 
            var goLang = new SubjectTagUpdateDto 
            {
                Id = 56,
                Title = "GoLang"
            };

            var goLangUpdated = await _repository.UpdateAsync(goLang);
            Assert.Equal(CrudStatus.NotFound, goLangUpdated); 
            // The database does not know about goLang, which is why it can't be updated.
        }

        [Fact]
        public async Task DeleteAsync_given_an_existing_subjectTag_returns_Deleted() 
        {
            var cSharp = new SubjectTagDto(1, "C#");

            var cSharpDeleted = await _repository.DeleteAsync(cSharp.Id);

            Assert.Equal(CrudStatus.Deleted, cSharpDeleted);
        }

        [Fact]
        public async Task DeleteAsync_given_non_existing_subjectTag_returns_notFound()
        {
            var goLangDeleted = await _repository.DeleteAsync(10);
            Assert.Equal(CrudStatus.NotFound, goLangDeleted); 
            // It can't delete a subjectTag that does not exists in the database
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