using System;
namespace Kruger.Application.DTOs
{
    public class ParkingRecordDto
    {
        public int Id { get; set; }
        public int CarOwnerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int ParkingPlaceId { get; set; }
        public decimal RateValue { get; set; }
        public string RateDescription { get; set; }
        public int CarId { get; set; }
        public string CarOwnerFullName { get; set; }
        public string CarPlate { get; set; }
        public string ParkingPlaceDescription { get; set; }
        public decimal TotalCost { get; set; }
        public string TotalTime
        {
            get
            {
                var total = EndTime.GetValueOrDefault(DateTime.Now) - StartTime;
                return total.ToString(@"hh\:mm\:ss");
            }
        }
        public string Status {
            get
            {
                return EndTime.HasValue ? "Ended" : "Started";
            }
        }
    }
}
