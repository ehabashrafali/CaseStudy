namespace CaseStudy.Domain.Employee
{
    using CaseStudy.Application.Commands.CreateEmployee;
    using CaseStudy.Domain.Department;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public Guid Id { get; private set; }
        public string Name { get; set; } = string.Empty;
        [ConcurrencyCheck]
        public Guid Version { get; set; } = Guid.NewGuid();
        public string Email { get; set; } = string.Empty;
        public DateOnly HireDate { get; set; }
        public EmployeeStatus Status { get; set; }
        public Department Department { get; set; }

        private readonly List<Logs.Logs> _logs = [];
        public IReadOnlyCollection<Logs.Logs> Logs => _logs;
        public bool IsDeleted { get; set; }
        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

        public void AddLogs(Logs.Logs logs)
        {
            _logs.Add(logs);
        }
    }
}

