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

        public DbSet<User> Users { get; set; }

        public virtual DbSet<Application> Applications { get; set; }

        public virtual DbSet<QualificationInformation> QualificationsInformation { get; set; }

        public virtual DbSet<Message> Messages  { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Configurations.UserConfiguration());
            builder.ApplyConfiguration(new Configurations.ApplicationConfiguration());
            builder.ApplyConfiguration(new Configurations.QualificatonInformationConfiguration());
            builder.ApplyConfiguration(new Configurations.MessageConfiguration());
        }
    }
}
