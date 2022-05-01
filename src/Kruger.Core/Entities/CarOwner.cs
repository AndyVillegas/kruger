using Kruger.Core.Enums;
using System;

namespace Kruger.Core.Entities
{
    public class CarOwner : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public IdType IdType { get; set; }
        public string IdValue { get; set; }
        public DateTime? LastParking { get; set; }
    }
}
