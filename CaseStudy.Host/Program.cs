using CaseStudy.Application.Commands.CreateEmployee;
using CaseStudy.Application.Queries.GetDepartment;
using CaseStudy.Application.Queries.Repositories;
using CaseStudy.Domain.Repositories;
using CaseStudy.Infrastructure.API.Controllers;
using CaseStudy.Infrastructure.DataBase;
using CaseStudy.Infrastructure.DataBase.Departments.Repositories;
using CaseStudy.Infrastructure.DataBase.Employees.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<CaseStudyDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
});

builder.Services.AddScoped<IDepartmentCommandRepository, DepartmentCommandsRepository>();
builder.Services.AddScoped<IEmployeeCommandRepository, EmployeeCommandRepository>();
builder.Services.AddScoped<IDepartmentQueriesRepository, DepartmentQueriesRepository>();
builder.Services.AddScoped<IEmployeeQueriesRepository, EmployeeQueriesRepository>();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblyContaining<CreateEmployeeCommand>();
    cfg.RegisterServicesFromAssembly(typeof(GetDepartmentQuery).Assembly);
});

builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(DepartmentController).Assembly)
    .AddApplicationPart(typeof(EmployeeController).Assembly)
    .AddApplicationPart(typeof(GetDepartmentQuery).Assembly);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.CustomSchemaIds(type => type.FullName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
