using Microsoft.EntityFrameworkCore;
using Module4HW5.Entities;
using Module4HW5.EntityConfigurations;

namespace Module4HW5
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        public DbSet<OfficeEntity> Office { get; set; } = null!;

        public DbSet<TitleEntity> Title { get; set; } = null!;

        public DbSet<ProjectEntity> Projects { get; set; } = null!;
        public DbSet<EmployeeProjectEntity> EmployeeProjects { get; set; } = null!;
        public DbSet<ClientEntity> Clients { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new OfficeConfiguration());
            modelBuilder.ApplyConfiguration(new TitleConfiguration());
            modelBuilder.ApplyConfiguration(new ProjectConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeProjectConfiguration());
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}
