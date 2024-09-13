using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BCommerce.CommonEntities.Shared.Infrastructure.Context
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "AppSettings"))
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connectionString = configuration.GetConnectionString(nameof(AppDbContext));
            builder.UseNpgsql(connectionString);
            return new AppDbContext(builder.Options);
        }
    }
}