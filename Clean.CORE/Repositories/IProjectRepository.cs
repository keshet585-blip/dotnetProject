using Clean.CORE.Entities;
using Clean.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.CORE.IRepositories
{
    public interface IProjectRepository : IRepository<Project>
    {

        public IEnumerable<Project> SearchProject(string keyword);

        // מביא את כל הפרויקטים עם כל העובדים
        public IEnumerable<Project> GetAllWithAssignments();

        // מביא פרויקט לפי Id כולל כל העובדים שלו
        public Project? GetByIdWithAssignments(int id);

        //מביא את הפרויקט עם העובדים עם השיוכים של העובדים עבור חישוב ציון לפרויקט
        public   Task<Project?> GetByIdWithDetailsAsync(int id);

    }
}
