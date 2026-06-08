using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Models;

namespace RentAll_WebAPIs.Services
{
    public interface IBookingService
    {
        Task<List<BookingResponseDto>> GetAllBookingsAsync();

        Task<BookingResponseDto?> GetBookingByIdAsync(int id);

        Task<BookingResponseDto> CreateBookingAsync(CreateBookingDto dto);

        Task<bool> UpdateBookingStatusAsync(int id, string status);

        Task<List<BookingResponseDto>>
            GetBookingsByEquipmentAsync(int equipmentId);

        Task<List<BookingResponseDto>>
            GetBookingsByOwnerAsync(int ownerId);

        Task<bool> CancelBookingAsync(int id);

        Task<bool> IsEquipmentAvailableAsync(
            int equipmentId,
            DateTime startDate,
            DateTime endDate);

        Task<List<BookingStatusHistory>>
            GetHistoryByBookingAsync(int bookingId);
    }
}