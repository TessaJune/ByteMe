// using System.IO;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Design;
// using Microsoft.Extensions.Configuration;

// namespace Trainor.Storage {
//     public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
//     {
//         public DataContext CreateDbContext(string[] args)
//         {
//             var configuration = new ConfigurationBuilder()
//             .SetBasePath(Directory.GetCurrentDirectory())
//             .AddUserSecrets<Program>()
//             .AddJsonFile("appsettings.json")
//             .Build();

//             var connectionString = configuration.GetConnectionString("Trainor");

//             var optionsBuilder = new DbContextOptionsBuilder<DataContext>()
//             .UseSqlServer(connectionString);

//             return new DataContext(optionsBuilder.Options);
//             //throw new System.NotImplementedException();
//         }
//     }
// }