namespace Kruger.Application.DTOs
{
    public class ParkingPlaceDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RateId { get; set; }
        public string RateDescription { get; set; }
        public decimal RateHourlyCost { get; set; }
    }
}
