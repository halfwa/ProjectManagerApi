using Microsoft.EntityFrameworkCore;
using ProjectManagerApi.Data.Configurations;
using ProjectManagerApi.Models.Employees;
using ProjectManagerApi.Models.Projects;
using ProjectManagerApi.Models.Services;

namespace ProjectManagerApi.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Position> Positions { get; set; }  

        public DbSet<Service> Services { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PositionConfiguration());

            builder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithOne(p => p.Employee)
                .HasForeignKey<Employee>(e => e.PositionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.Development.json")
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("MsSqlConnection"));

            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}
