using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> message)
        {
            message.HasKey(x => x.Id);

            message
                .Property(x => x.Content)
                .IsRequired();

            message
                .Property(x => x.StartDate)
                .IsRequired();
        }
    }
}
