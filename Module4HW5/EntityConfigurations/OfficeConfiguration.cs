using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class OfficeConfiguration : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Office").HasKey(o => o.OfficeId);
            entityTypeBuilder.Property(o => o.OfficeId).HasColumnName("OfficeId").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(o => o.Title).IsRequired().HasColumnName("Title").HasMaxLength(100);
            entityTypeBuilder.Property(o => o.Location).IsRequired().HasColumnName("Location").HasMaxLength(100);
        }
    }
}
