namespace RentAll_WebAPIs.DTOs
{
    public class StatusHistoryDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime ChangedAt { get; set; }
    }
}
