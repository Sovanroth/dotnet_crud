using MyApi.Properties.Dtos;
using MyApi.Properties.Model;
using MyApi.Properties.Repository;
using MyApi.Properties.ResponseMessage;

namespace MyApi.Properties.Service
{
    public class StudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<StudentResponse<IEnumerable<Student>>> GetAllStudents()
        {
            try
            {
                var students = await _studentRepository.GetAllStudents();
                return new StudentResponse<IEnumerable<Student>>
                {
                    Error = false,
                    Message = "Get Successfully",
                    Students = students
                };
            }
            catch (Exception e)
            {
                return new StudentResponse<IEnumerable<Student>>
                {
                    Error = true,
                    Message = "Error getting students",
                    Students = null
                };
            }
        }

        public async Task<StudentResponse<IEnumerable<Student>>> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);
                if (student == null)
                {
                    return new StudentResponse<IEnumerable<Student>>
                    {
                        Error = true,
                        Message = "Student not found",
                        Students = null
                    };
                }

                return new StudentResponse<IEnumerable<Student>>
                {
                    Error = false,
                    Message = "Get Successfully",
                    Students = new List<Student> { student }
                };
            }
            catch (Exception e)
            {
                return new StudentResponse<IEnumerable<Student>>
                {
                    Error = true,
                    Message = "Error getting student",
                    Students = null
                };
            }
        }

        public async Task<CreateStudent> CreateStudent(Student student)
        {
            try
            {
                var createdStudent = await _studentRepository.CreateStudent(student);
                return new CreateStudent
                {
                    Error = false,
                    Message = "Created Successfully",
                    Student = createdStudent
                };
            }
            catch (Exception e)
            {
                return new CreateStudent
                {
                    Error = true,
                    Message = "Error creating student",
                    Student = null
                };
            }
        }

        public async Task<UpdateStudent> UpdateStudent(int id, StudentDto studentDto)
        {
            try
            {
                var existingStudent = await _studentRepository.GetStudentById(id);
                if (existingStudent == null)
                {
                    return new UpdateStudent
                    {
                        Error = true,
                        Message = "Student not found",
                        Student = null
                    };
                }

                if (!string.IsNullOrEmpty(studentDto.Name))
                {
                    existingStudent.Name = studentDto.Name;
                }

                if (studentDto.Age > 0)
                {
                    existingStudent.Age = studentDto.Age;
                }

                if (!string.IsNullOrEmpty(studentDto.Email))
                {
                    existingStudent.Email = studentDto.Email;
                }

                await _studentRepository.UpdateStudent(existingStudent);

                return new UpdateStudent
                {
                    Error = false,
                    Message = "Student updated successfully",
                    Student = existingStudent
                };
            }
            catch (Exception e)
            {
                return new UpdateStudent
                {
                    Error = true,
                    Message = "Error updating student",
                    Student = null
                };
            }
        }

        public async Task<DeleteStudentResponse> DeleteStudent(int id)
        {
            try
            {
                var student = await _studentRepository.GetStudentById(id);
                if (student == null)
                {
                    return new DeleteStudentResponse
                    {
                        Error = true,
                        Message = "Student not found",
                        Student = null
                    };
                }

                await _studentRepository.DeleteStudent(id);

                return new DeleteStudentResponse
                {
                    Error = false,
                    Message = "Deleted Successfully",
                    Student = student
                };
            }
            catch (Exception e)
            {
                return new DeleteStudentResponse
                {
                    Error = true,
                    Message = "Error deleting student",
                    Student = null
                };
            }
        }
    }
}
