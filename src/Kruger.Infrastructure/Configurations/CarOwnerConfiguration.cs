using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kruger.Infrastructure.Configurations
{
    public class CarOwnerConfiguration : BaseEntityConfiguration<CarOwner>
    {
        public CarOwnerConfiguration(EntityTypeBuilder<CarOwner> entity) : base(entity)
        {
            entity.ToTable("CarOwner");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.IdValue)
                .HasMaxLength(15)
                .IsRequired();

            entity.Property(e => e.IdType)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}
