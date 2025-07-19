using CaseStudy.Domain.Employee;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseStudy.Infrastructure.DataBase.Employees.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(d => d.Id)
                    .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.Status)
                   .IsRequired();

            builder.Property(e => e.HireDate);

            builder.Property(e => e.Version)
                   .IsRequired()
                   .IsConcurrencyToken();

            builder.HasOne(e => e.Department)
                   .WithMany(d => d.Employees)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
