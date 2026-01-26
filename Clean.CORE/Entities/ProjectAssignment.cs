namespace Clean.CORE.Entities
{
    public class ProjectAssignment
    {

        public int Id { get; set; }
        //forign key
        public int ProjectId { get; set; }
        //forign key
        public int EmployeeId { get; set; }
        public string EmployeeRoleInProject { get; set; }
        public Project Project { get; set; }
        public Employee Employee { get; set; }
    }
}



