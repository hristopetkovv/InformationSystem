using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address.HasKey(x => x.Id);

            address
                .Property(x => x.Municipality)
                .IsRequired();

            address
                .Property(x => x.Region)
                .IsRequired();

            address
                .Property(x => x.City)
                .IsRequired();

            address
                .Property(x => x.Street)
                .IsRequired();
        }
    }
}
