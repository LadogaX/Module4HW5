using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Employee").HasKey(e => e.EmployeeId);
            entityTypeBuilder.Property(e => e.EmployeeId).HasColumnName("EmployeeId").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(e => e.FirstName).IsRequired().HasColumnName("FirstName").HasMaxLength(50);
            entityTypeBuilder.Property(e => e.LastName).IsRequired().HasColumnName("LastName").HasMaxLength(50);
            entityTypeBuilder.Property(e => e.HiredDate).IsRequired().HasColumnName("HiredDate").HasColumnType("datetime2(7)");
            entityTypeBuilder.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth").HasColumnType("date");
            entityTypeBuilder.Property(e => e.OfficeId).IsRequired().HasColumnName("OfficeId").HasColumnType("int");
            entityTypeBuilder.Property(e => e.TitleId).IsRequired().HasColumnName("TitleId").HasColumnType("int");

            entityTypeBuilder.HasOne(e => e.Office)
                             .WithMany(o => o.Employees)
                             .HasForeignKey(e => e.OfficeId)
                             .OnDelete(DeleteBehavior.Cascade);
            entityTypeBuilder.HasOne(e => e.Title)
                             .WithMany(o => o.Employees)
                             .HasForeignKey(e => e.TitleId)
                             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}