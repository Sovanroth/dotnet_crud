using Microsoft.AspNetCore.Mvc;
using MyApi.Properties.Dtos;
using MyApi.Properties.Models;
using MyApi.Properties.ResponseMessage;
using MyApi.Properties.Service;

namespace MyApi.Properties.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class StudentsController(StudentService studentService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<StudentResponse<IEnumerable<Student>>>> GetStudents()
        {
            return await studentService.GetAllStudents();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentResponse<IEnumerable<Student>>>> GetStudentById(int id)
        {
            return await studentService.GetStudentById(id);
        }

        [HttpPost]
        public async Task<ActionResult<CreateStudent>> CreateStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return await studentService.CreateStudent(student);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateStudent>> UpdateStudent(int id, StudentDto studentDto)
        {
            return await studentService.UpdateStudent(id, studentDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteStudentResponse>> DeleteStudent(int id)
        {
            return await studentService.DeleteStudent(id);
        }
    }
}