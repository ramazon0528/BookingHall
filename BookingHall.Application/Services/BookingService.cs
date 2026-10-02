using BookingHall.Application.Abstractions;
using BookingHall.Application.DTO;
using BookingHall.Domain.Models;

namespace BookingHall.Application.Services;

public class BookingService
{
    private readonly IBookingRepository _bookingRepository;

    public BookingService(IBookingRepository bookingRepository)
    {
        _bookingRepository = bookingRepository;
    }

    private decimal CalculatePrice(decimal basePrice, DateTime bookingStart)
    {
        var time = bookingStart.TimeOfDay;

        if (time >= TimeSpan.FromHours(12) && time < TimeSpan.FromHours(14))
            return basePrice * 1.15m;

        if (time >= TimeSpan.FromHours(6) && time < TimeSpan.FromHours(9))
            return basePrice * 0.90m;

        if (time >= TimeSpan.FromHours(18) && time < TimeSpan.FromHours(23))
            return basePrice * 0.80m;

        return basePrice;
    }

    public async Task<Booking> AddAsync(CreateBookingDto dto)
    {
        var hall = await _bookingRepository.GetHall(dto.HallId);

        if (hall == null)
            throw new Exception("Зал не найден!");

        var price = CalculatePrice(hall.PricePerHour, dto.BookingStart);

        var booking = new Booking()
        {
            HallId = dto.HallId,
            BookingStart = dto.BookingStart,
            Duration = dto.Duration,
            BookingEnd = dto.BookingStart.Add(dto.Duration),

            PricePerHour = price,
        };

        foreach (var item in dto.BookingItems)
        {
            var hallItem = hall.HallItems.FirstOrDefault(x => x.ServiceId == item.ServiceId);

            if (hallItem == null)
                throw new Exception($"Услуга с id {item.ServiceId} не доступна для этого зала!");

            booking.BookingItems.Add(
                new BookingItem() { ServiceId = hallItem.ServiceId, Price = hallItem.Service.Price }
            );
        }

        await _bookingRepository.AddASync(booking);

        return booking;
    }
}
