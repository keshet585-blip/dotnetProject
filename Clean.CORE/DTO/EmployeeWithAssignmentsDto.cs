using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class EmployeeWithAssignmentsDto
    {
        public int Id { get; set; }

        // שם העובד
        public string FullName { get; set; }

        // תפקיד העובד
        public string Role { get; set; }
        public List<ProjectAssignmentDto> Assignments { get; set; } = new();
    }
}
