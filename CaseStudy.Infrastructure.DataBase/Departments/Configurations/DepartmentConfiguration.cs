using CaseStudy.Domain.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseStudy.Infrastructure.DataBase.Departments.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Id)
                        .ValueGeneratedOnAdd();


            builder.Property(d => d.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
