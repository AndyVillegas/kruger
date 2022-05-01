using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kruger.Infrastructure.Configurations
{
    public class RateConfiguration : BaseEntityConfiguration<Rate>
    {
        public RateConfiguration(EntityTypeBuilder<Rate> entity) : base(entity)
        {
            entity.ToTable("Rate");

            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(e => e.HourlyCost)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            entity.Property(e => e.MinimumCost)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
        }
    }
}
