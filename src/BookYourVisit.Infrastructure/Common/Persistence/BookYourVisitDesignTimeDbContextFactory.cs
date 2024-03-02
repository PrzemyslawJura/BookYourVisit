using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookYourVisit.Infrastructure.Common.Persistence;
public class BookYourVisitDesignTimeDbContextFactory : IDesignTimeDbContextFactory<BookYourVisitDbContext>
{
    public BookYourVisitDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory().Replace("Infrastructure","Api"))
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<BookYourVisitDbContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new BookYourVisitDbContext(optionsBuilder.Options);
    }
}