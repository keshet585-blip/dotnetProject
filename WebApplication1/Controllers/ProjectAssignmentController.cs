using Microsoft.AspNetCore.Mvc;
using Clean.CORE.Entities;
using Clean.CORE.Services;
using System;
using AutoMapper;
using Clean.API.Models;
using Clean.CORE.DTO;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// Controller לניהול שיוכים בין עובדים לפרויקטים
    /// משתמש ב-Dependency Injection לקבלת מקור הנתונים
    /// </summary>
    [ApiController]
    [Route("api/assignments")]
    public class ProjectAssignmentController : ControllerBase
    {
        private readonly IProjectAssignmentService _service;
        private readonly IMapper _mapper;

        /// <summary>
        /// קונסטרקטור - מקבל את מקור הנתונים דרך Dependency Injection
        /// </summary>
        /// <param name="service">מקור הנתונים המוזרק</param>
        public ProjectAssignmentController(IProjectAssignmentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// שליפת כל השיוכים
        /// </summary>
        [HttpGet]
        public IActionResult GetAllAssignments()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// שליפת שיוך בודד לפי מזהה
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetAssignmentById(int id)
        {
            var assignment = _service.GetById(id);
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// שליפת כל השיוכים של עובד מסוים
        /// </summary>
        [HttpGet("by-employee/{employeeId}")]
        public IActionResult GetAssignmentsByEmployee(int employeeId)
        {
            var list = _service.GetAssignmentsByEmployee(employeeId);
            return Ok(list);
        }

        /// <summary>
        /// שליפת כל השיוכים של פרויקט מסוים
        /// </summary>
        [HttpGet("by-project/{projectId}")]
        public IActionResult GetAssignmentsByProject(int projectId)
        {
            var list = _service.GetAssignmentsByProject(projectId);
            return Ok(list);
        }

        /// <summary>
        /// הוספת שיוך חדש בין עובד לפרויקט
        /// </summary>
        [HttpPost]
        public IActionResult AddAssignment(ProjectAssignmentPost assignment)
        {
            var added = _service.Add(_mapper.Map<ProjectAssignment>(assignment));
            return Ok(added);
        }

        /// <summary>
        /// עדכון נתוני שיוך קיים
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateAssignment(int id, ProjectAssignmentPost updated)
        {
            var assignment = _service.Update(id, _mapper.Map<ProjectAssignment>(updated));
            if (assignment == null)
                return NotFound("שיוך לא נמצא");

            return Ok(assignment);
        }

        /// <summary>
        /// מחיקת שיוך
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteAssignment(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound("שיוך לא נמצא");

            return Ok("נמחק בהצלחה");
        }
    }
}

