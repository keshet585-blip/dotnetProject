
using Clean.CORE.DTO;
using System.ComponentModel.DataAnnotations;

namespace Clean.CORE.Entities
{
    public class Employee
    {

        // מזהה ייחודי של עובד
       

        public int Id { get; set; }

            // שם העובד
            public string FullName { get; set; }

            // תפקיד העובד
            public string Role { get; set; }

        //היחיד כי employee אחד מקושר להרבה פרויקטים
        //רשימת הפרויקטים שלו
        public List<ProjectAssignment> Assignments { get; set; } = new();
    }
}

