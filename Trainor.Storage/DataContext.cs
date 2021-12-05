using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Resource> Resources => Set<Resource>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(u => u.GivenName)
                .HasMaxLength(50);

            modelBuilder
                .Entity<User>()
                .Property(u => u.LastName)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Link)
                .IsRequired();
        }
    }
}