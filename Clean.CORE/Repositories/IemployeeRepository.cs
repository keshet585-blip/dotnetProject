using Clean.CORE.Entities;
using Clean.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.IRepositories
{
    public interface IemployeeRepository: IRepository<Employee>
    {
        public IEnumerable<Employee> GetByRole(string role);

       
        public Employee? GetEmployeeWithAssignments(int id);

        public void AddAssignment(int employeeId, int projectId, string roleInProject);

    }
}
