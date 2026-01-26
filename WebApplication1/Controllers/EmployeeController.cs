using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Clean.CORE.Entities;
using Clean.SERVICE;
using System.Linq;
using System;
using Clean.CORE.Services;
using Clean.CORE.DTO;
using AutoMapper;
using Clean.API.Models;

namespace WebApplication1.Controllers
{


    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        private readonly IMapper _mapper;
        public EmployeeController(IEmployeeService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

            /// <summary>
            /// שליפת כל העובדים
            /// </summary>
            [HttpGet]
            public IActionResult GetAllEmployees()
            {
                return Ok(_service.GetAll());
            }

            /// <summary>
            /// שליפת עובד לפי מזהה
            /// </summary>
            [HttpGet("{id}")]
            public IActionResult GetEmployeeById(int id)
            {
                var employee = _service.GetById(id);
                if (employee == null)
                    return NotFound("עובד לא נמצא");

                return Ok(employee);
            }

        /// <summary>
        /// שליפת עובד עם שיוכים
        /// </summary>
        [HttpGet("{id}/assignments")]
        public IActionResult GetEmployeeWithAssignments(int id)
        {
            var employee = _service.GetEmployeeWithAssignments(id);
            if (employee == null)
                return NotFound("עובד לא נמצא");

            return Ok(employee);
        }

        ///// <summary>
        ///// הוספת שיוך לעובד (שליחת projectId ו-roleInProject בגוף הבקשה)
        ///// </summary>
        //[HttpPost("{employeeId}/assignments")]
        //public IActionResult AddAssignmentToEmployee(int employeeId, [FromBody] ProjectAssignementDto dto)
        //{
        //    _service.AddAssignment();
        //    return NoContent();
        //}

        /// <summary>
        /// הוספת עובד חדש
        /// </summary>
        [HttpPost]
        public IActionResult AddEmployee(EmployeePost employee)
        {
            var added = _service.Add(_mapper.Map<Employee>(employee));
            return Ok(added);
        }

        /// <summary>
        /// עדכון עובד קיים
        /// </summary>
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeePost updated)
        {
            var employee = _service.Update(id, _mapper.Map<Employee>(updated));
            if (employee == null)
                return NotFound("עובד לא נמצא");

            return Ok(employee);
        }
        /// <summary>
        /// מחיקת עובד לפי מזהה
        /// </summary>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound("עובד לא נמצא");

            return Ok($"העובד עם מזהה {id} נמחק בהצלחה");
        }

        /// <summary>
        /// פעולה נוספת: שליפת רשימת העובדים לפי תפקיד
        /// </summary>
        [HttpGet("by-role/{role}")]
        public IActionResult GetByRole(string role)
        {
            var list = _service.GetByRole(role);
            return Ok(list);
        }

        }
    }

