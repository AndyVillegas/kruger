using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kruger.Infrastructure.Configurations
{
    public class CarConfiguration : BaseEntityConfiguration<Car>
    {
        public CarConfiguration(EntityTypeBuilder<Car> entity) : base(entity)
        {
            entity.ToTable("Car");

            entity.Property(e => e.Plate).IsRequired().HasMaxLength(6);
        }
    }
}
