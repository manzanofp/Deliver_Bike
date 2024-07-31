using Deliver.Bike.Domain.Entities.RentyEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deliver.Bike.Persistence.Mapping;
public class RentMapping : IEntityTypeConfiguration<Rent>
{
    public void Configure(EntityTypeBuilder<Rent> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.InitDate)
            .IsRequired();

        builder
            .Property(x => x.EndDate)
            .IsRequired();

        builder
            .Property(x => x.ExpectedEndDate)
            .IsRequired();

        builder
            .Property(x => x.Value)
            .IsRequired();

        builder.HasOne(r => r.Motorcycle)
               .WithMany(m => m.Rents)
               .HasForeignKey(r => r.MotorcycleId);

        builder.HasOne(r => r.DeliverMan)
               .WithMany(dm => dm.Rents)
               .HasForeignKey(r => r.DeliverManId)
               .IsRequired();
    }
}
