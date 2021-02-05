using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> application)
        {
            application.HasKey(x => x.Id);

            application
                .Property(x => x.FirstName)
                .IsRequired();

            application
                .Property(x => x.LastName)
                .IsRequired();
        }
    }
}
