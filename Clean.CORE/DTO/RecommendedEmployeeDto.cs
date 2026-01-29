using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class RecommendedEmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public int CurrentProjectCount { get; set; }
        public string MatchReason { get; set; }
    }
}
