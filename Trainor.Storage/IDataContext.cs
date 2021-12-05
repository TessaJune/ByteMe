using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Trainor.Storage.Entities;


namespace Trainor.Storage
{
    public interface IDataContext : IDisposable
    {
        DbSet<UserDto> Users { get; }
        DbSet<ResourceDto> Resources { get; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}