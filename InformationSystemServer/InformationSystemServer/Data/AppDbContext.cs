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
        }

        public DbSet<User> Users { get; set; }
        public virtual DbSet<Addres> Addreses { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<QualificatonInformation> QualificatonsInformation { get; set; }
    }
}
