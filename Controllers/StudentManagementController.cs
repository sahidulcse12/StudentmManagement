using Microsoft.AspNetCore.Mvc;
using StudentmManagement.DTO;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;

namespace StudentmManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentManagementController:ControllerBase
    {
        private readonly ILogger<Student> _logger;
        private readonly IStudentManagementService _service;

        public StudentManagementController(ILogger<Student>logger, IStudentManagementService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            var item = await _service.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetSingleStudent(int id)
        {
            var result = await _service.GetById(id);
            if (result is null)
                return NotFound("Student not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task AddStudent(StudentDto student)
        {
            await _service.Add(student);
        }

        [HttpPost]
        public async Task AddCourse(CourseDto course)
        {
            await _service.AddSingleCourse(course);
            //return Ok();
        }

        [HttpPost]
        public async Task AddSemester(SemesterDto semester)
        {
            await _service.AddSingleSemester(semester);
            //return Ok();
        }

        [HttpPut("{id}")]
        public async Task Update(int id, StudentDto student)
        {
            var result = await _service.GetById(id);
            if (result is null)
                return;

            await _service.Update(id,student);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var result = await _service.GetById(id);
            if (result is null)
                return;

            await _service.Delete(id);
        }
    }
}
