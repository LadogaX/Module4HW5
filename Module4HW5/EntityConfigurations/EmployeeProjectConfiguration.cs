using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class EmployeeProjectConfiguration : IEntityTypeConfiguration<EmployeeProjectEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeProjectEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("EmployeeProject").HasKey(e => e.EmployeeProjectId);
            entityTypeBuilder.Property(e => e.EmployeeProjectId).HasColumnName("EmployeeProjectId").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(e => e.Rate).IsRequired().HasColumnName("Rate").HasColumnType("money");
            entityTypeBuilder.Property(e => e.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");
            entityTypeBuilder.Property(e => e.EmployeeId).IsRequired().HasColumnName("EmployeeId").HasColumnType("int");
            entityTypeBuilder.Property(e => e.ProjectId).IsRequired().HasColumnName("ProjectId").HasColumnType("int");

            entityTypeBuilder.HasOne(e => e.Projects)
                             .WithMany(o => o.EmployeeProjects)
                             .HasForeignKey(e => e.ProjectId)
                             .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder.HasOne(e => e.Employees)
                             .WithMany(o => o.EmployeeProjects)
                             .HasForeignKey(e => e.EmployeeId)
                             .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
