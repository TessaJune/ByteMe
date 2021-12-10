using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
        {
        }
        public DbSet<User> Users => Set<User>();

        public DbSet<Author> Authors => Set<Author>();

        public DbSet<Resource> Resources => Set<Resource>();

        public DbSet<SubjectTag> SubjectTags => Set<SubjectTag>();

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
                .Entity<Author>()
                .Property(a => a.GivenName)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Author>()
                .Property(a => a.LastName)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .HasMaxLength(50);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Link)
                .IsRequired();

            modelBuilder
                .Entity<SubjectTag>()
                .Property(s => s.Title)
                .HasMaxLength(50);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Trainor"); // I think this is what makes migrations work
            }
        }
    }
}