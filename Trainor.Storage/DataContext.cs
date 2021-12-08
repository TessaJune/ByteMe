using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;

namespace Trainor.Storage
{
    public class DataContext : DbContext, IDataContext
    {
        public DbSet<User> Users => Set<User>(); // { get; set; }

        public DbSet<Resource> Resources => Set<Resource>();

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer("Server=.;Database=TrainerDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
            // if (!optionsBuilder.IsConfigured)
            // {
            //     var connectionString = @"Server=localhost;Database=TrainorDB;User ID=sa;Password=postgres";

            //     optionsBuilder.UseSqlServer(connectionString);
            // }
        } 

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