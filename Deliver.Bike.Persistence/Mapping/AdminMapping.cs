using Deliver.Bike.Domain.Entities.AdminEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Deliver.Bike.Persistence.Mapping;

public class AdminMapping : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder
            .Property(x => x.Id)
            .IsRequired();

        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Email)
            .HasMaxLength(120);
    }
}
