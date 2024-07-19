using System.ComponentModel.DataAnnotations;

namespace MyApi.Properties.Models;

public class Student
{
    
    public int Id { set; get; }
    
    [StringLength(50)]
    public string Name { get; set; }
    public int Age { get; set; }
    [StringLength(50)]
    public string Email { get; set; }
}