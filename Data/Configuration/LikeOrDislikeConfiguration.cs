using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class LikeOrDislikeConfiguration : IEntityTypeConfiguration<LikeOrDislike>
    {
        public void Configure(EntityTypeBuilder<LikeOrDislike> builder)
        {
            builder.HasKey(t => new { t.IdeaId, t.UserId });

            builder.ToTable("LikeOrDislikes");

            builder.HasOne(t => t.Idea).WithMany(pc => pc.LikeOrDislikes)
                .HasForeignKey(pc => pc.IdeaId).OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(t => t.User).WithMany(pc => pc.LikeOrDislikes)
              .HasForeignKey(pc => pc.UserId).OnDelete(DeleteBehavior.Restrict); ;
            builder.Property(x => x.IsLike).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.IsDislike).IsRequired().HasDefaultValue(false);
        }

    }
}
