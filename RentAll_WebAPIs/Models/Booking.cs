public class Booking
{
    public int Id { get; set; }

    public int EquipmentId { get; set; }

    public string RenterName { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int TotalDays { get; set; }

    public decimal TotalPrice { get; set; }

    public decimal DepositAmount { get; set; }

    public string Status { get; set; }

    public DateTime CreatedAt { get; set; }

    public Equipment Equipment { get; set; }
}