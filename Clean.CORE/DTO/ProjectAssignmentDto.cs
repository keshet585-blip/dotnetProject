using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class ProjectAssignmentDto
    {
        public int Id { get; set; }
        //forign key
        public int ProjectId { get; set; }
        //forign key
        public int EmployeeId { get; set; }
        public string EmployeeRoleInProject { get; set; }
    }
}
