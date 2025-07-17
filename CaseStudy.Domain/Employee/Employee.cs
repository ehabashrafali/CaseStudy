namespace CaseStudy.Domain.Employee
{
    using CaseStudy.Application.Commands.CreateEmployee;
    using CaseStudy.Domain.Department;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        [ConcurrencyCheck]
        public Guid Version { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Department Department { get; set; }
    }
}

