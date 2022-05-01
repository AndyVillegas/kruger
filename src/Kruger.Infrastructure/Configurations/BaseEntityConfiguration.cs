using Kruger.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Kruger.Infrastructure.Configurations
{
    public abstract class BaseEntityConfiguration<T> where T : BaseEntity
    {
        public BaseEntityConfiguration(EntityTypeBuilder<T> entity)
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.DeletedAt)
                .HasColumnType("datetime");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("getdate()")
                .HasColumnType("datetime");

            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime");

            entity.HasQueryFilter(e => !e.DeletedAt.HasValue);
        }
    }
}
