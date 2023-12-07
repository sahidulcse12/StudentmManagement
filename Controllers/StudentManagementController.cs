using Microsoft.AspNetCore.Mvc;
using StudentmManagement.Interfaces;
using StudentmManagement.Models;

namespace StudentmManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentManagementController:ControllerBase
    {
        private readonly ILogger<StudentsModel> _logger;
        private readonly IstudentManagement _iStudentManagement;

        public StudentManagementController(ILogger<StudentsModel>logger, IstudentManagement iStudentManagement)
        {
            _logger = logger;
            _iStudentManagement = iStudentManagement;
        }

        [HttpGet]
        public ActionResult<List<StudentsModel>> Get()
        {
            var item = _iStudentManagement.GetAll();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public ActionResult<StudentsModel> Get(string id) 
        { 
            var studnet = _iStudentManagement.GetById(id);
            if(studnet== null)
            {
                return NotFound();
            }
            return Ok(studnet);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StudentsModel newStudnet) 
        { 
            _iStudentManagement.AddNewStudent(newStudnet);
            return CreatedAtAction(nameof(Get),new {id=newStudnet.StudentId},newStudnet);
        }

        [HttpPut]
        public IActionResult Put(string id,[FromBody] StudentsModel updateStudnet)
        {
            var success = _iStudentManagement.Update(id, updateStudnet);
            if(!success)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var foundStudnet = _iStudentManagement.Delete(id);
            if(!foundStudnet)
            {
                return NotFound();
            }
            return NoContent() ;

        }
    }
}
