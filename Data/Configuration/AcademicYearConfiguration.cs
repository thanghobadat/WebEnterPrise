using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configuration
{
    public class AcademicYearConfiguration : IEntityTypeConfiguration<AcademicYear>
    {
        public void Configure(EntityTypeBuilder<AcademicYear> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.ToTable("AcademicYears");
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

        }

    }
}
