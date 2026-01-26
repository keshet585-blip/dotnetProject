using Clean.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }

        // שם הפרויקט
        public string Name { get; set; }

        // תיאור קצר של הפרויקט  

        public string Description { get; set; }
    }
}
