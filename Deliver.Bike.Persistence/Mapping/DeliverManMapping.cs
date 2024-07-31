using Deliver.Bike.Domain.Contracts;
using Deliver.Bike.Domain.Entities.DeliverEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deliver.Bike.Persistence.Mapping;

public class DeliverManMapping : IEntityTypeConfiguration<DeliverMan>
{
    public void Configure(EntityTypeBuilder<DeliverMan> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.Cnpj)
            .IsRequired()
            .HasMaxLength(50);

        builder
            .Property(x => x.BirthDate)
            .IsRequired();

        builder
            .Property(x => x.CnhNumber)
            .IsRequired()
            .HasMaxLength(11);

        builder
            .Property(x => x.CnhType)
            .IsRequired();

        builder
            .Property(x => x.CnhImage);

    }
}
