using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BookingHall.Infrastructure.Data;

public class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var options = new DbContextOptionsBuilder<AppDbContext>();

        options.UseSqlite($"Data Source={DbPathProvider.GetDbPath()}");

        return new AppDbContext(options.Options);
    }
}
