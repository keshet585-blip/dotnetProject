namespace Clean.API.Models
{
    public class ProjectAssignmentPost
    {
        public int ProjectId { get; set; }
        //forign key
        public int EmployeeId { get; set; }
        public string EmployeeRoleInProject { get; set; }
    }
}
