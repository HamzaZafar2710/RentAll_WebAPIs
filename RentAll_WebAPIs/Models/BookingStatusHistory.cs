using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentAll_WebAPIs.Models
{

    public class BookingStatusHistory
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        [StringLength(20)]
        public string Status { get; set; }= string.Empty;

        public DateTime ChangedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(BookingId))]
        public Booking Booking { get; set; } = null!;
    }
}
