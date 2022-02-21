using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Data.Configuration
{
    public class IdeaConfiguration : IEntityTypeConfiguration<Idea>
    {
        public void Configure(EntityTypeBuilder<Idea> builder)
        {
            builder.ToTable("Ideas");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();


            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.View).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Like).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Dislike).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsAnonymously).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.CreatedAt).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EditDate).IsRequired().HasDefaultValue(DateTime.Now.AddDays(7));
            builder.Property(x => x.FinalDate).IsRequired().HasDefaultValue(DateTime.Now.AddDays(11));
        }
    }
}
