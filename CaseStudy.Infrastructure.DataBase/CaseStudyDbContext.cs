using CaseStudy.Domain.Department;
using CaseStudy.Domain.Employee;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Infrastructure.DataBase
{
    public class CaseStudyDbContext(DbContextOptions<CaseStudyDbContext> options) : DbContext(options)
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CaseStudyDbContext).Assembly);
        }
    }
}
