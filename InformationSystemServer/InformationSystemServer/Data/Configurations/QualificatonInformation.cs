using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class QualificatonInformationConfiguration : IEntityTypeConfiguration<QualificationInformation>
    {
        public void Configure(EntityTypeBuilder<QualificationInformation> qualification)
        {
            qualification.HasKey(x => x.Id);

            qualification
                .Property(x => x.TypeQualification)
                .IsRequired();

            qualification
                .Property(x => x.StartDate)
                .IsRequired();

            qualification
                .Property(x => x.EndDate)
                .IsRequired();

            qualification
                .Property(x => x.DurationDays)
                .IsRequired();

            qualification
                .Property(x => x.Description)
                .IsRequired();

            qualification
                .HasOne(x => x.Application)
                .WithMany(a => a.QualificationInformation)
                .HasForeignKey(x => x.ApplicationId);
        }
    }
}
