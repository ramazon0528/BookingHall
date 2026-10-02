using BookingHall.Application.Abstractions;
using BookingHall.Infrastructure.Data;
using BookingHall.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingHall.Infrastructure.Extensions;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        var dbpath = DbPathProvider.GetDbPath();

        services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbpath}"));

        services.AddScoped<IHallRepository, HallRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();

        return services;
    }
}
