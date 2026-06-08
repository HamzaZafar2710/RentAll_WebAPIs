namespace RentAll_WebAPIs.DTOs
{
    public class CreateBookingDto
    {
        public int EquipmentId { get; set; }

        public string RenterName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}