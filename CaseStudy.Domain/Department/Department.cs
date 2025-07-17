namespace CaseStudy.Domain.Department;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    private readonly List<Employee.Employee> _employees = new();
    public IReadOnlyCollection<Employee.Employee> Employeess => _employees;

}
