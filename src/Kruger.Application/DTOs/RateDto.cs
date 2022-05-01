namespace Kruger.Application.DTOs
{
    public class RateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal HourlyCost { get; set; }
        public decimal MinimumCost { get; set; }
    }
}
