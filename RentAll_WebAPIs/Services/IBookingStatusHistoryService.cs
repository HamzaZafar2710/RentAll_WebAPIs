using RentAll_WebAPIs.DTOs;

namespace RentAll_WebAPIs.Services
{
    public interface IBookingStatusHistoryService
    {
        /// Appends a new status record for the given booking.
        Task LogStatusChangeAsync(int bookingId, string status);
        /// Returns the full ordered status timeline for a booking.
        Task<List<StatusHistoryDto>> GetHistoryByBookingAsync(int bookingId);
    }
}
