using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;

namespace Trainor.Storage {
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<UserDto> Users => Set<UserDto>();
        public DbSet<ResourceDto> Resources => Set<ResourceDto>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<UserDto>()
                .Property(u => u.GivenName)
                .HasMaxLength(50);
                
            modelBuilder.Entity<UserDto>()
                .Property(u => u.LastName)
                .HasMaxLength(50);

            modelBuilder
                .Entity<ResourceCreateDto>()
                .Property(r => r.Name)
                .HasMaxLength(50);

            modelBuilder
                .Entity<ResourceCreateDto>()
                .Property(r => r.Link);
        }
    }
}