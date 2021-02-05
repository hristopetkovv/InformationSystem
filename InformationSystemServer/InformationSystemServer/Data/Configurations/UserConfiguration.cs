using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> user)
        {
            user.HasKey(x => x.Id);

            user
                .Property(x => x.Username)
                .IsRequired();

            user
                .Property(x => x.FirstName)
                .IsRequired();

            user
                .Property(x => x.LastName)
                .IsRequired();
        }
    }
}
