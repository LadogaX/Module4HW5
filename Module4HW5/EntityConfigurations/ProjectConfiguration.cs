using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW5.Entities;

namespace Module4HW5.EntityConfigurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<ProjectEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectEntity> entityTypeBuilder)
        {
            entityTypeBuilder.ToTable("Project").HasKey(t => t.ProjectId);
            entityTypeBuilder.Property(t => t.ProjectId).HasColumnName("ProjectId").ValueGeneratedOnAdd();
            entityTypeBuilder.Property(t => t.Name).IsRequired().HasColumnName("Name").HasMaxLength(50);
            entityTypeBuilder.Property(t => t.Budget).IsRequired().HasColumnName("Budget").HasColumnType("money");
            entityTypeBuilder.Property(t => t.StartedDate).IsRequired().HasColumnName("StartedDate").HasColumnType("datetime2(7)");
        }
    }
}
