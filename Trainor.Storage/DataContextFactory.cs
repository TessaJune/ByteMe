using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Trainor.Storage {

    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>{
        public DataContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<Program>()
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Futurama");

        var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(connectionString);

        return new DataContext(optionsBuilder.Options);
        }
    }
}