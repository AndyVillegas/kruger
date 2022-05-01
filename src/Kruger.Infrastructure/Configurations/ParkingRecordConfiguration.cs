using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kruger.Infrastructure.Configurations
{
    public class ParkingRecordConfiguration : BaseEntityConfiguration<ParkingRecord>
    {
        public ParkingRecordConfiguration(EntityTypeBuilder<ParkingRecord> entity) : base(entity)
        {
            entity.ToTable("ParkingRecord");

            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .IsRequired()
                .HasDefaultValue(DateTime.Now);

            entity.Property(e => e.EndTime)
                .HasColumnType("datetime");

            entity.Property(e => e.RateDescription)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.RateValue)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.TotalCost)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.HasOne(e => e.Car)
                .WithMany()
                .HasForeignKey(e => e.CarId);

            entity.HasOne(e => e.CarOwner)
                .WithMany()
                .HasForeignKey(e => e.CarOwnerId);

            entity.HasOne(e => e.ParkingPlace)
                .WithMany()
                .HasForeignKey(e => e.ParkingPlaceId);
        }
    }
}
