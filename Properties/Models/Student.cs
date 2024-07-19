using System.ComponentModel.DataAnnotations;

namespace MyApi.Properties.Model;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
}