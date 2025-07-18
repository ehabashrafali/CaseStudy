
using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Application.Queries.Repositories;
using CaseStudy.Domain.Repositories;
using CaseStudy.Infrastructure.DataBase;
using CaseStudy.Infrastructure.DataBase.Departments.Repositories;
using CaseStudy.Infrastructure.DataBase.Employees.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Debug;

namespace CaseStudy.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<CaseStudyDbContext>(options =>
            {
                var serviceProvider = builder.Services.BuildServiceProvider();
                var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
                loggerFactory.AddProvider(new DebugLoggerProvider());
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddScoped<IDepartmentCommandRepository, DepartmentCommandsRepository>();
            builder.Services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
            builder.Services.AddScoped<IDepartmentQueriesRepository, DepartmentQueriesRepository>();
            builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();

            builder.Services.AddTransient<IPipelineBehavior<CreateEmployeeCommand, Guid>, CreateEmployeeCommandPreparerBehavior>();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
