using Microsoft.AspNetCore.Mvc;
using MyApi.Properties.Dtos;
using MyApi.Properties.Model;
using MyApi.Properties.ResponseMessage;
using MyApi.Properties.Service;

namespace MyApi.Properties.Controller
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentsController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<StudentResponse<IEnumerable<Student>>>> GetStudents()
        {
            return await _studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse<IEnumerable<Student>>>> GetStudentById(int id)
        {
            return await _studentService.GetStudentById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CreateStudent>> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await _studentService.CreateStudent(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateStudent>> UpdateStudent(int id, StudentDto studentDto)
        {
            return await _studentService.UpdateStudent(id, studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStudentResponse>> DeleteStudent(int id)
        {
            return await _studentService.DeleteStudent(id);
        }
    }
}