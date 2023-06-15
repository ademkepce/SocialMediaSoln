using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SocialMediaSoln.Domain.Entities;

namespace SocialMediaSoln.Persistence.Configuraitons
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Comments).HasForeignKey(x => x.AppUserId);
        }
    }
}
