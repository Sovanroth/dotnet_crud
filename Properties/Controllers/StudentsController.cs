using Microsoft.AspNetCore.Mvc;
using MyApi.Properties.Dtos;
using MyApi.Properties.Model;
using MyApi.Properties.Repository;
using MyApi.Properties.ResponseMessage;

namespace MyApi.Properties.Controller;

[Route("/api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;

    public StudentsController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
    {
        try
        {
            var students = await _studentRepository.GetAllStudents();
            var response = new StudentResponse<IEnumerable<Student>>
            {
                Error = false,
                Message = "Get Successfully",
                Students = students
            };
            return Ok(response);
        }
        catch ( Exception e)
        {
            var response = new StudentResponse<IEnumerable<Student>>
            {
                Error = true,
                Message = "Error getting student",
                Students = null
            };
            Console.WriteLine(e);
            return StatusCode(500, response);
        }
        
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<IEnumerable<Student>>> GetStudentById(int id)
    {
        try
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                var response = new StudentResponse<IEnumerable<Student>?>
                {
                    Error = true,
                    Message = "Error getting student",
                    Students = null
                };
                return NotFound(response);
            }
            else
            {
                var response = new ResponseOneStudent()
                {
                    Error = false,
                    Message = "Get Successfully",
                    Student = student,
                };
                return Ok(response);
            }
    
        }
        catch (Exception e)
        {
            var response = new StudentResponse<IEnumerable<Student>?>
            {
                Error = true,
                Message = "Error getting student",
                Students = null
            };
            Console.WriteLine(e);
            return StatusCode(500, response);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Student>> CreateStudent(Student student)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createdStudent = await _studentRepository.CreateStudent(student);

            var response = new CreateStudent()
            {
                Error = false,
                Message = "Created Successfully",
                Student = createdStudent
            };
            
            return Ok(response);
        }
        catch ( Exception e)
        {
            Console.WriteLine(e);
            var response = new CreateStudent()
            {
                Error = true,
                Message = "Error posting student",
                Student = null
            };
            return StatusCode(500, response);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateStudent(int id, StudentDto student)
    {
        try
        {
            var existingStudent = await _studentRepository.GetStudentById(id);
            if (existingStudent == null)
            {
                var response = new UpdateStudent()
                {
                    Error = true,
                    Message = "Student not found",
                    Student = null,
                };
                return NotFound(response);
            }
            
            if (!string.IsNullOrEmpty(student.Name))
            {
                existingStudent.Name = student.Name;
            }

            if (student.Age > 0)
            {
                existingStudent.Age = student.Age;
            }

            if (!string.IsNullOrEmpty(student.Email))
            {
                existingStudent.Email = student.Email;
            }

            await _studentRepository.UpdateStudent(existingStudent);
            var successResponse = new UpdateStudent()
            {
                Error = false,
                Message = "Student updated successfully",
                Student = existingStudent
            };
            return Ok(successResponse);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            var errorResponse = new UpdateStudent()
            {
                Error = true,
                Message = "Error updating student",
                Student = null
            };
            return StatusCode(500, errorResponse);
        }
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult<IEnumerable<Student>>> DeleteStudentData(int id)
    {
        try
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null)
            {
                var response = new DeleteStudentResponse()
                {
                    Error = true,
                    Message = "Student not found",
                    Student = null,
                };
                return NotFound(response);
            }
            else
            {
                await _studentRepository.DeleteStudent(id);
                var response = new DeleteStudentResponse()
                {
                    Error = false,
                    Message = "Deleted Successfully",
                    Student = student,
                };
                return Ok(response);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            var response = new DeleteStudentResponse()
            {
                Error = true,
                Message = "Error Deleting Student",
                Student = null
            };
            return StatusCode(500, response);
        }
    }


}