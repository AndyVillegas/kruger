namespace Kruger.Core.Entities
{
    public class Rate : BaseEntity
    {
        public string Description { get; set; }
        public decimal HourlyCost { get; set; }
        public decimal MinimumCost { get; set; }
    }
}
