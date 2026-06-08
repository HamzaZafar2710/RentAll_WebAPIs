using Microsoft.AspNetCore.Mvc;
using RentAll_WebAPIs.DTOs;
using RentAll_WebAPIs.Services;

namespace RentAll_WebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public async Task<ActionResult<List<BookingResponseDto>>> GetAll()
        {
            return await _bookingService.GetAllBookingsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingResponseDto>> GetById(int id)
        {
            var booking = await _bookingService.GetBookingByIdAsync(id);

            if (booking == null)
                return NotFound();

            return booking;
        }

        [HttpPost]
        public async Task<ActionResult<BookingResponseDto>> Create(CreateBookingDto dto)
        {
            var booking = await _bookingService.CreateBookingAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = booking.Id },
                booking);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            UpdateBookingStatusDto dto)
        {
            var updated =
                await _bookingService.UpdateBookingStatusAsync(
                    id,
                    dto.Status);

            if (!updated)
                return NotFound();

            return NoContent();
        }
    }
}