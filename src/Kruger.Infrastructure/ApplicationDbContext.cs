using Kruger.Core.Entities;
using Kruger.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kruger.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarOwner> CarOwners { get; set; }
        public DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public DbSet<ParkingRecord> ParkingRecords { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfiguration(modelBuilder);
        }

        private void ModelConfiguration(ModelBuilder modelBuilder)
        {
            new CarConfiguration(modelBuilder.Entity<Car>());
            new CarOwnerConfiguration(modelBuilder.Entity<CarOwner>());
            new ParkingPlaceConfiguration(modelBuilder.Entity<ParkingPlace>());
            new ParkingRecordConfiguration(modelBuilder.Entity<ParkingRecord>());
            new RateConfiguration(modelBuilder.Entity<Rate>());
            new UserConfiguration(modelBuilder.Entity<User>());
        }
    }
}
