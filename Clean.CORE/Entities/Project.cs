using Clean.CORE.DTO;
using System.Collections.Generic;

namespace Clean.CORE.Entities
{
    public class Project
    {
        // מחלקה המייצגת פרויקט במערכת
        // מזהה ייחודי של הפרויקט
        public int Id { get; set; }

        // שם הפרויקט
        public string Name { get; set; }

        // תיאור קצר של הפרויקט  

        public string Description { get; set; }


        // רשימת שיוכים בין עובדים לפרויקט זה
        //פרויקט אחד מקושר להרבה assignement
        //השם של הפרויקט איפה מופיע הרבה? לא כאן כאן פעם אחת ולכן כאן היחיד
        public List<ProjectAssignment> Assignments { get; set; } = new();
    }
}
