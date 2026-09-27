using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingHall.Infrastructure.Data;

public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var dbDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "MyMedia"
        );

        Directory.CreateDirectory(dbDirectory);

        var dbPath = Path.Combine(dbDirectory, "MyMedia.db");

        var options = new DbContextOptionsBuilder<AppDbContext>();

        options.UseSqlite($"Data Source={dbPath}");

        return new AppDbContext(options.Options);
    }
}
