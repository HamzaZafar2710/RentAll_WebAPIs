using Microsoft.AspNetCore.Mvc;
using RentAll_WebAPIs.Services;

namespace RentAll_WebAPIs.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingStatusHistoryController : ControllerBase
    {
        private readonly IBookingStatusHistoryService _historyService;

        public BookingStatusHistoryController(IBookingStatusHistoryService historyService)
        {
            _historyService = historyService;
        }

        [HttpGet("{id:int}/history")]
        public async Task<IActionResult> GetHistory(int id)
        {
            var history = await _historyService.GetHistoryByBookingAsync(id);

            if (history == null || history.Count == 0)
                return NotFound(new { message = $"No status history found for booking {id}." });

            return Ok(history);
        }
    }
}
