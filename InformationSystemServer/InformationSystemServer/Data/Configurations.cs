using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data
{
    public class Configurations
    {
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Username).IsRequired();
                builder.Property(x => x.FirstName).IsRequired();
                builder.Property(x => x.LastName).IsRequired();
            }
        }

        public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
        {
            public void Configure(EntityTypeBuilder<Application> builder)
            {
                builder.HasKey(x => x.Id);
                builder.Property(x => x.FirstName).IsRequired();
                builder.Property(x => x.LastName).IsRequired();
            }
        }

        public class QualificatonInformationConfiguration : IEntityTypeConfiguration<QualificatonInformation>
        {
            public void Configure(EntityTypeBuilder<QualificatonInformation> builder)
            {
                builder.ToTable("QualificatonInformation");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.TypeQualification).IsRequired();
                builder.Property(x => x.StartDate).IsRequired();
                builder.Property(x => x.EndDate).IsRequired();
                builder.Property(x => x.DurationDays).IsRequired();
                builder.Property(x => x.Description).IsRequired();
            }
        }
       
        public class AddressConfiguration : IEntityTypeConfiguration<Address>
        {
            public void Configure(EntityTypeBuilder<Address> builder)
            {
                builder.ToTable("Address");
                builder.HasKey(x => x.Id);
                builder.Property(x => x.Municipality).IsRequired();
                builder.Property(x => x.Region).IsRequired();
                builder.Property(x => x.City).IsRequired();
                builder.Property(x => x.Street).IsRequired();
            }
        }
    }
}
