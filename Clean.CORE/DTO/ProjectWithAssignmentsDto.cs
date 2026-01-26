using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class ProjectWithAssignmentsDto
    {
        public int Id { get; set; }

        // שם הפרויקט
        public string Name { get; set; }

        // תיאור קצר של הפרויקט
        public string Description { get; set; }

        public List<ProjectAssignmentDto> Assignments { get; set; } = new();
    }
}
