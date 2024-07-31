using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deliver.Bike.Persistence.Mapping;

public class MotorcycleMapping : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .HasKey(x => x.Id);

        builder.Property(x => x.Identifier)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(m => m.Year)
               .IsRequired()
               .HasMaxLength(4);

        builder.Property(m => m.Model)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(m => m.Plate)
               .IsRequired()
               .HasMaxLength(7);

        builder.HasIndex("Plate").IsUnique();
    }
}
