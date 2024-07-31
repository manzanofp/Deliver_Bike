using Deliver.Bike.Domain.Entities.AdminEntity;
using Deliver.Bike.Domain.Entities.DeliverEntity;
using Deliver.Bike.Domain.Entities.MotorcycleEntity;
using Deliver.Bike.Domain.Entities.RentyEntity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Deliver.Bike.Persistence.Context;
public class ApplicationDbContext : DbContext
{

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<Motorcycle> MotorCycles => Set<Motorcycle>();
    public DbSet<DeliverMan> DeliverMans => Set<DeliverMan>();
    public DbSet<Rent> Rents => Set<Rent>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
