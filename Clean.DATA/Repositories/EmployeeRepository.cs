using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.DATA.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clean.DATA.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IemployeeRepository
    {
        private readonly IDataContext _context;

        public EmployeeRepository(DataContext context) : base(context)
        {
            _context = context;
        }

 
        public IEnumerable<Employee> GetByRole(string role)
        {
            return _context.Employees
                .Where(e => e.Role.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public Employee? GetEmployeeWithAssignments(int id)
        {
            return _context.Employees
                                      .Include(e => e.Assignments)
                                      .ThenInclude(a => a.Project)
                                      .FirstOrDefault(e => e.Id == id);
        }
        public void AddAssignment(int employeeId, int projectId, string roleInProject)
        {
            var assignment = new ProjectAssignment
            {
                EmployeeId = employeeId,
                ProjectId = projectId,
                EmployeeRoleInProject = roleInProject
            };
            _context.Assignments.Add(assignment);
            _context.SaveChanges();
        }

    }
}
