using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kruger.Infrastructure.Configurations
{
    public class ParkingPlaceConfiguration : BaseEntityConfiguration<ParkingPlace>
    {
        public ParkingPlaceConfiguration(EntityTypeBuilder<ParkingPlace> entity) : base(entity)
        {
            entity.ToTable("ParkingPlace");

            entity.Property(e => e.Capacity)
                .IsRequired();

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(e => e.Rate)
                .WithMany()
                .HasForeignKey(e => e.RateId)
                .HasPrincipalKey(e => e.Id);
        }
    }
}
