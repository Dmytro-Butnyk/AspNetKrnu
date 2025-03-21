using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Data;

/// <summary>
/// Factory for creating DbContexts for the SportsBookingSystem database
/// </summary>
public class SportsBookDbContextFactory : IDesignTimeDbContextFactory<SportsBookDbContext>
{
    public SportsBookDbContext CreateDbContext(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string relativePath = "../Presentation";

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(currentDirectory, relativePath))
            .AddJsonFile("appsettings.json")
            .Build();

        string? connectionString = configuration.GetConnectionString("LocalConnectionString");

        var optionsBuilder = new DbContextOptionsBuilder<SportsBookDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new SportsBookDbContext(optionsBuilder.Options);
    }
}