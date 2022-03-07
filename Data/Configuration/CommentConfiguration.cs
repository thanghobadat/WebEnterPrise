using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.IsAnonymously).IsRequired().HasDefaultValue(false);
            builder.HasOne(t => t.User).WithMany(pc => pc.Comments)
              .HasForeignKey(pc => pc.UserId);
            builder.HasOne(t => t.Idea).WithMany(pc => pc.Comments)
              .HasForeignKey(pc => pc.IdeaId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
