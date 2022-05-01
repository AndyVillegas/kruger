using System;

namespace Kruger.Core.Entities
{
    public class ParkingRecord : BaseEntity
    {
        public int CarOwnerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ParkingPlaceId { get; set; }
        public decimal RateValue { get; set; }
        public string RateDescription { get; set; }
        public int CarId { get; set; }
        public decimal TotalCost { get; set; }
        public string Note { get; set; }

        public Car Car { get; set; }
        public CarOwner CarOwner { get; set; }
        public ParkingPlace ParkingPlace { get; set; }
    }
}
