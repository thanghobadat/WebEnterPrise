using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("AppUsers");
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.HasOne(t => t.Department).WithMany(pc => pc.AppUser)
              .HasForeignKey(pc => pc.DepartmentId);
        }

    }
}
