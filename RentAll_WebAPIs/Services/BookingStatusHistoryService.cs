using Microsoft.EntityFrameworkCore;
using RentAll_WebAPIs.Data;
using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Models;

namespace RentAll_WebAPIs.Services
{
    public class BookingStatusHistoryService : IBookingStatusHistoryService
    {
        private readonly AppDbContext _context;

        public BookingStatusHistoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task LogStatusChangeAsync(int bookingId, string status)
        {
            var entry = new BookingStatusHistory
            {
                BookingId = bookingId,
                Status = status,
                ChangedAt = DateTime.UtcNow
            };

            await _context.BookingStatusHistories.AddAsync(entry);
            await _context.SaveChangesAsync();
        }

        public async Task<List<StatusHistoryDto>> GetHistoryByBookingAsync(int bookingId)
        {
            return await _context.BookingStatusHistories
                .Where(h => h.BookingId == bookingId)
                .OrderBy(h => h.ChangedAt)
                .Select(h => new StatusHistoryDto
                {
                    Id = h.Id,
                    BookingId = h.BookingId,
                    Status = h.Status,
                    ChangedAt = h.ChangedAt
                })
                .ToListAsync();
        }
    }
}
