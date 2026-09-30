using BookingHall.Application.Services;
using BookingHall.Infrastructure.Data;
using BookingHall.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddControllers();

builder.Services.AddScoped<HallService>();
builder.Services.AddScoped<ServiceService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
