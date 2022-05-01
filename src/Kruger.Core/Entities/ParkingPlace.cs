using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kruger.Core.Entities
{
    public class ParkingPlace : BaseEntity
    {
        public string Description { get; set; }
        public int Capacity { get; set; }
        public int RateId { get; set; }

        public Rate Rate { get; set; }
    }
}
