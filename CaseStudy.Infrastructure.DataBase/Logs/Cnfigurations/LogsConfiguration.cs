using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseStudy.Infrastructure.DataBase.Logs.Cnfigurations
{
    public class LogsConfiguration : IEntityTypeConfiguration<Domain.Logs.Logs>
    {
        public void Configure(EntityTypeBuilder<Domain.Logs.Logs> builder)
        {

            builder.HasKey(l => new { l.Employee.Id, l.CreatedOn });

            builder.Property(l => l.CreatedOn)
                   .IsRequired();

            builder.Property(l => l.UpdatedOn);

            builder.Property(l => l.ActionType)
                   .IsRequired();

            builder.HasOne(l => l.Employee)
                   .WithMany(e => e.Logs)
                   .IsRequired()
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
