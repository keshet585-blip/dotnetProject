using AutoMapper;
using Clean.CORE.DTO;
using Clean.CORE.Entities;
using Clean.CORE.IRepositories;
using Clean.CORE.Repositories;
using Clean.CORE.Services;
using Clean.DATA.Repositories;
using System.Collections.Generic;

namespace Clean.SERVICE
{
    public class EmployeeService :IEmployeeService // מגדירה את הלוגיקה העיסקית עבור עובדים
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repositoryManager,IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {
            var list= _repositoryManager.Employees.GetAll();
            return _mapper.Map<IEnumerable<EmployeeDto>>(list);
        }

        public EmployeeDto? GetById(int id)
        {
            var Employee= _repositoryManager.Employees.GetById(id);
            return _mapper.Map<EmployeeDto>(Employee);
        }

        public EmployeeDto Add(Employee employee)
        {
            var newEmployee = _repositoryManager.Employees.Add(employee);
            _repositoryManager.Save();
            return _mapper.Map<EmployeeDto>(newEmployee);
        }

        public EmployeeDto? Update(int id, Employee updated)
        {
            var emp = _repositoryManager.Employees.Update(id, updated);
            _repositoryManager.Save();
            return _mapper.Map<EmployeeDto>(emp);
        }

        public bool Delete(int id)
        {
            var isDeleted = _repositoryManager.Employees.Delete(id);
            if (isDeleted)
            {
                _repositoryManager.Save();
            }
            return isDeleted;
        }

        public IEnumerable<EmployeeDto> GetByRole(string role)
        {
            var list = _repositoryManager.Employees.GetByRole(role);
            return _mapper.Map<IEnumerable<EmployeeDto>>(list);
        }

        public EmployeeWithAssignmentsDto? GetEmployeeWithAssignments(int id)
        {
            var emp = _repositoryManager.Employees.GetEmployeeWithAssignments(id);
            return _mapper.Map<EmployeeWithAssignmentsDto>(emp);
        }

        public IEnumerable<RecommendedEmployeeDto> GetRecommendedEmployees(int projectId,string requiredRole)
        {
            //שלב ראשון העובדים המתאימים רק מי שהוא בתפקיד 
            // שליפת כל העובדים מהרפוזיטורי
            var allEmployees = _repositoryManager.Employees.GetAll()
                .Where(e => e.Role.ToLower() == requiredRole.ToLower());
            // לוגיקה: מסננים עובדים שכבר משויכים לפרויקט הזה וממיינים לפי עומס
            var recommended = allEmployees
                .Where(e => !e.Assignments.Any(a => a.ProjectId == projectId))
                .OrderBy(e => e.Assignments.Count)
                .Select(e => new RecommendedEmployeeDto
                {
                    EmployeeId = e.Id,
                    FullName = e.FullName,
                    CurrentProjectCount = e.Assignments.Count,
                    MatchReason = e.Assignments.Count == 0 ? "פנוי לחלוטין" : "עומס עבודה נמוך"
                })
                .Take(5); // מחזירים רק את ה-5 הכי פנויים

            return recommended;
        }
    }
}
