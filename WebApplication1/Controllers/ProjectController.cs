using AutoMapper;
using Clean.API.Models;
using Clean.CORE.Entities;
using Clean.CORE.Services;
using Clean.SERVICE;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;
        private readonly IMapper _mapper;

        public ProjectController(IProjectService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// שליפת רשימת כל הפרויקטים
        /// </summary>
        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_service.GetAll());
        }

        /// <summary>
        /// שליפת כל הפרויקטים כולל שיוכים
        /// </summary>
        [HttpGet("with-assignments")]
        public IActionResult GetAllWithAssignments()
        {
            return Ok(_service.GetAllWithAssignments());
        }

        /// <summary>
        /// שליפת פרויקט בודד לפי מזהה
        /// </summary>
        [HttpGet("{id}")]
        public IActionResult GetProjectById(int id)
        {
            var project = _service.GetById(id);
            if (project == null)
                return NotFound("פרויקט לא נמצא");

            return Ok(project);
        }

        /// <summary>
        /// שליפת פרויקט כולל שיוכים
        /// </summary>
        [HttpGet("{id}/assignments")]
        public IActionResult GetProjectByIdWithAssignments(int id)
        {
            var project = _service.GetByIdWithAssignments(id);
            if (project == null)
                return NotFound("פרויקט לא נמצא");

            return Ok(project);
        }

        /// <summary>
        /// הוספת פרויקט חדש
        /// </summary>
        [HttpPost]
        public IActionResult AddProject(ProjectPost project)
        {
            var added = _service.Add(_mapper.Map<Project>(project));
            return Ok(added);
        }

        /// <summary>
        /// עדכון פרויקט קיים
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateProject(int id, ProjectPost updated)
        {
            var project = _service.Update(id, _mapper.Map<Project>(updated));
            if (project == null)
                return NotFound("פרויקט לא נמצא");

            return Ok(project);
        }

        /// <summary>
        /// מחיקת פרויקט לפי מזהה
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteProject(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound("פרויקט לא נמצא");

            return Ok($"הפרויקט עם מזהה {id} נמחק בהצלחה");
        }

        /// <summary>
        /// חיפוש פרויקטים לפי מילה בשם
        /// </summary>
        [HttpGet("search/{keyword}")]
        public IActionResult SearchProject(string keyword)
        {
            var results = _service.Search(keyword);
            return Ok(results);
        }

        /// <summary>
        /// ניתוח יציבות הפרויקט וחיזוי סיכונים על בסיס עומס הצוות
        /// </summary>
        [HttpGet("{id}/stability-analysis")]
        public async Task<IActionResult> GetProjectStability(int id)
        {
            var analysis = await _service.GetProjectStabilityAsync(id);

            if (analysis == null)
                return NotFound("הפרויקט המבוקש לא נמצא.");
            return Ok(analysis);
        }
    }
}
