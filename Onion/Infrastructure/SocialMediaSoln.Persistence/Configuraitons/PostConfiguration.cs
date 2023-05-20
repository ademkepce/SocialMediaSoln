using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Persistence.Configuraitons
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.AppUserId);
        }
    }
}
