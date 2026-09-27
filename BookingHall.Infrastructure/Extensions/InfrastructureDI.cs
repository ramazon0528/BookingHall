using BookingHall.Application.Abstractions;
using BookingHall.Infrastructure.Data;
using BookingHall.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookingHall.Infrastructure.Extensions;

public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString
    )
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

        services.AddScoped<IHallRepository, HallRepository>();

        return services;
    }
}
