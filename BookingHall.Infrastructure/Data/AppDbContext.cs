using BookingHall.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingHall.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Service> Services { get; set; }
    public DbSet<Hall> Halls { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<BookingItem> BookingItems { get; set; }
    public DbSet<HallItem> HallItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>(b =>
        {
            b.HasOne(x => x.Hall)
                .WithMany(x => x.Bookings)
                .HasForeignKey(x => x.HallId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<HallItem>(h =>
        {
            h.HasKey(x => new { x.HallId, x.ServiceId });

            h.HasOne(x => x.Hall)
                .WithMany(x => x.HallItems)
                .HasForeignKey(x => x.HallId)
                .OnDelete(DeleteBehavior.Cascade);

            h.HasOne(x => x.Service)
                .WithMany(x => x.HallItems)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<BookingItem>(b =>
        {
            b.HasOne(x => x.Booking)
                .WithMany(x => x.BookingItems)
                .HasForeignKey(x => x.BookingId)
                .OnDelete(DeleteBehavior.Cascade);

            b.HasOne(x => x.Service)
                .WithMany(x => x.BookingItems)
                .HasForeignKey(x => x.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
