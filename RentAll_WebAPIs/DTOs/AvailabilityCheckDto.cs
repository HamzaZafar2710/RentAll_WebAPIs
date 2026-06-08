namespace RentAll_WebAPIs.DTOs
{
    public class AvailabilityCheckDto
    {
        public int EquipmentId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}