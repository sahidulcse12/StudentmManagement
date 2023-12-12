using Microsoft.AspNetCore.Mvc;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;

namespace StudentmManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public ActionResult Get()
        {
            var item = _service.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id) 
        { 
            var studnet = _service.GetById(id);
            if(studnet == null)
            {
                return NotFound();
            }
            return Ok(studnet);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Student newStudnet) 
        { 
            _service.Add(newStudnet);
            return CreatedAtAction(nameof(Get),new {id=newStudnet.StudentId},newStudnet);
        }

        [HttpPut]
        public IActionResult Update(string id,[FromBody] Student updateStudnet)
        {
            var success = _service.Update(id, updateStudnet);
            if(!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var success = _service.Delete(id);
            if(!success)
            {
                return NotFound();
            }
            return NoContent() ;

        }
    }
}
