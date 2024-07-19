using System.ComponentModel.DataAnnotations;

namespace MyApi.Properties.Model;

public class Student
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public int Age { get; set; }
    [Required]
    public string Email { get; set; }
}