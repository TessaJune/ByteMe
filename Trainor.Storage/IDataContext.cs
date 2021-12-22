using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;


namespace Trainor.Storage
{
    public interface IDataContext : IDisposable
    {
        DbSet<User> Users { get; }

        DbSet<Author> Authors { get; }

        DbSet<Resource> Resources { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}