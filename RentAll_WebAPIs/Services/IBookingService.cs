using RentAll_WebAPIs.DTOs;

namespace RentAll_WebAPIs.Services
{
    public interface IBookingService
    {
        Task<List<BookingResponseDto>> GetAllBookingsAsync();

        Task<BookingResponseDto?> GetBookingByIdAsync(int id);

        Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto);

        Task<bool> UpdateBookingStatusAsync(int id, string status);
    }
}