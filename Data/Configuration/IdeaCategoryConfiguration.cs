using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class IdeaCategoryConfiguration : IEntityTypeConfiguration<IdeaCategory>
    {
        public void Configure(EntityTypeBuilder<IdeaCategory> builder)
        {
            builder.HasKey(t => new { t.IdeaId, t.CategoryId });

            builder.ToTable("IdeaCategories");

            builder.HasOne(t => t.Idea).WithMany(pc => pc.IdeaCategories)
                .HasForeignKey(pc => pc.IdeaId);

            builder.HasOne(t => t.Category).WithMany(pc => pc.IdeaCategories)
              .HasForeignKey(pc => pc.CategoryId);
        }
    }
}
