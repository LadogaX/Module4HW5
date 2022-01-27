using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class TitleConfiguration : IEntityTypeConfiguration<TitleEntity>
    {
        public void Configure(EntityTypeBuilder<TitleEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Title").HasKey(t => t.TitleId);
            entityTypeBuilder.Property(t => t.TitleId).HasColumnName("TitleId").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
        }
    }
}