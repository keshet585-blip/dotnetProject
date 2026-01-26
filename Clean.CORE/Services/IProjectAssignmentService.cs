using Clean.CORE.Entities;
using Clean.CORE.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.Services
{
    public interface IProjectAssignmentService
    {

        public IEnumerable<ProjectAssignmentDto> GetAll();

        public ProjectAssignmentDto? GetById(int id);

        public ProjectAssignmentDto Add(ProjectAssignment assignment);

        public ProjectAssignmentDto? Update(int id, ProjectAssignment updated);

        public bool Delete(int id);

        public IEnumerable<ProjectAssignmentDto> GetByProject(int projectId);

        public IEnumerable<ProjectAssignmentDto> GetAssignmentsByEmployee(int employeeId);
        public IEnumerable<ProjectAssignmentDto> GetAssignmentsByProject(int projectId);
    }
}
