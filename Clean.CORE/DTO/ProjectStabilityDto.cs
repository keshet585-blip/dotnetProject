using System;
using System.Collections.Generic;
using System.Text;

namespace Clean.CORE.DTO
{
    public class ProjectStabilityDto
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int StabilityScore { get; set; } // ציון סופי 0-100
        public string RiskLevel { get; set; }    // "Low", "Medium", "High"
        public List<string> Insights { get; set; } = new(); // הסברים על הציון
    }
}
