
// using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.Configuration;
// using Trainor.Storage;
// using Microsoft.Extensions.DependencyInjection;
// using System.IO;

// // WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// // WebApplicationBuilder builder;
// // builder = WebApplication.CreateBuilder(args);

// // builder.Configuration.AddKeyPerFile("/run/secrets", optional: true);

// // builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Trainor")));
// // builder.Services.AddScoped<IDataContext, DataContext>();
// // builder.Services.AddScoped<IResourceRepository, ResourceRepository>();
// // builder.Services.AddScoped<IUserRepository, UserRepository>();

// namespace Trainor.Storage {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             var configuration = LoadConfiguration();
//             var connectionString = configuration.GetConnectionString("Trainor");

//             var optionsBuilder = new DbContextOptionsBuilder<DataContext>().UseSqlServer(connectionString);
//             using var context = new DataContext(optionsBuilder.Options);
//         }
//         static IConfiguration LoadConfiguration()
//         {
//             var builder = new ConfigurationBuilder()
//                 .SetBasePath(Directory.GetCurrentDirectory())
//                 .AddJsonFile("appsettings.json")
//                 .AddUserSecrets<Program>();

//             return builder.Build();
//         }
//     }
// }

// COULD BE DELETED