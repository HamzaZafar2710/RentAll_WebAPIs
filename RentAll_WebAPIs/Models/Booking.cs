using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentAll_WebAPIs.Models
{

    public class Booking
    {
        public int Id { get; set; }

        public int EquipmentId { get; set; }

        [Required]
        [StringLength(100)]
        public string RenterName { get; set; }= string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }= string.Empty;

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }= string.Empty;

        [Required]
        [StringLength(300)]
        public string Address { get; set; }= string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Range(1, 365)]
        public int TotalDays { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 9999999)]
        public decimal TotalPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 9999999)]
        public decimal DepositAmount { get; set; }

        [StringLength(20)]
        public string Status { get; set; }= string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey(nameof(EquipmentId))]
        public Equipment Equipment { get; set; } = null!;

        public ICollection<BookingStatusHistory> StatusHistory { get; set; } = new List<BookingStatusHistory>();
    }
}
