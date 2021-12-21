using System;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage;
using Trainor.Storage.Entities;
using Xunit;

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
            dataContext.Authors.AddRange(
                new Author { Id = 12, GivenName = "John", LastName = "Doe" },
                new Author { Id = 15, GivenName = "Jane", LastName = "Doe" });
            dataContext.SaveChanges();

            _context = dataContext;
            _repository = new ResourceRepository(_context);
        }

        [Fact]
        public async Task CreateAsync_creates_new_resource_with_createResourceDto_returns_created() { }

        [Fact]
        public async Task ReadAsync_reads_resource_with_existing_id_returns_ok() { }

        [Fact]
        public async Task ReadAsync_reads_resource_with_non_existing_id_returns_notFound() { }

        [Fact]
        public async Task UpdateAsync_updates_resource_with_existing_id_returns_true() { }

        [Fact]
        public async Task UpdateAsync_updates_resource_with_non_existing_id_returns_notFound() { }

        [Fact]
        public async Task DeleteAsync_given_an_existing_resource_returns_Deleted() { }

        [Fact]
        public async Task DeleteAsync_given_non_existing_resource_returns_notFound() { }

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