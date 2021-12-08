// using System.IO;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;

// namespace Trainor.Storage {

//     public class Program {
//         static void Main(string [] args)
//         {
//             var configuration = LoadConfiguration();
//             var connectionString = configuration.GetConnectionString("Futurama");

//             var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connectionString);
//             using var context = new DataContext(optionsBuilder.Options);
//         }

//         static IConfiguration LoadConfiguration() 
//         {
//             var builder = new ConfigurationBuilder()
//                             .SetBasePath(Directory.GetCurrentDirectory())
//                             .AddJsonFile("appsettings.json")
//                             .AddUserSecrets<Program>();
            
//             return builder.Build();
//         }
//     }
// }