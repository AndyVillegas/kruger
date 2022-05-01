using System;
using Kruger.Core.Enums;

namespace Kruger.Application.DTOs
{
    public class CarOwnerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string IdTypeDescription { get; set; }
        public IdType IdType { get; set; }
        public string IdValue { get; set; }
        public DateTime? LastParking { get; set; }
    }
}
