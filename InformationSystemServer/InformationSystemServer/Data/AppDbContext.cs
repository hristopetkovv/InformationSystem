using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystemServer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions db) : base(db)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Configurations.UserConfiguration());
            builder.ApplyConfiguration(new Configurations.ApplicationConfiguration());
            builder.ApplyConfiguration(new Configurations.QualificatonInformationConfiguration());
            builder.ApplyConfiguration(new Configurations.AddressConfiguration());
        }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<QualificatonInformation> QualificatonsInformation { get; set; }
    }
}
