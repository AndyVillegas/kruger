using System;

namespace Kruger.Application.DTOs
{
    public class FinishedParkingRecordDto
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Note { get; set; }
        public string CarOwnerFullName { get; set; }
        public string CarPlate { get; set; }
        public string ParkingPlaceDescription { get; set; }
        public decimal TotalCost { get; set; }
        public string TotalTime
        {
            get
            {
                var total = EndTime - StartTime;
                return total.ToString(@"hh\:mm\:ss");
            }
        }
    }
}
