using InformationSystemServer.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InformationSystemServer.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post.HasKey(x => x.Id);

            post
                .Property(x => x.Content)
                .IsRequired();

            post
           .Property(x => x.StartDate)
           .IsRequired();
        }
    }
}
