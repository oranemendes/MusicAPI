using System.IO;
using APIFilRouge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace APIFilRouge
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MusicContext>
    {
        public MusicContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<MusicContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString);
            
            return new MusicContext(builder.Options);
        }
    }
}