using MyApi.Properties.Model;

namespace MyApi.Properties.ResponseMessage;

public class StudentResponse<T>
{
    public bool Error { get; set; }
    public string? Message { get; set; }
    public T? Students { get; set; }

}

public class ResponseOneStudent
{
    public bool Error { get; set; }
    public string? Message { get; set; }
    public Student? Student { get; set; }
}

public class CreateStudent
{
    public bool Error { get; set; }
    public string? Message { get; set; }
    public Student? Student { get; set; }
}

public class UpdateStudent
{
    public bool Error { get; set; }
    public string? Message { get; set; }
    public Student? Student { get; set; }
}

public class DeleteStudentResponse
{
    public bool Error { get; set; }
    public string? Message { get; set; }
    public Student? Student { get; set; }
}