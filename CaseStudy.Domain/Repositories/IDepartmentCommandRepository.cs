﻿namespace CaseStudy.Domain.Repositories
{
    public interface IDepartmentCommandRepository
    {
        Task AddAsync(Department.Department department);

        Task<Department.Department> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
