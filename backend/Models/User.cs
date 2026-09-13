namespace Backend.Model;
using System.ComponentModel.DataAnnotations;


public class User
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = "";

    [Required] 
    [EmailAddress]
    public string Email { get; set; } = "";

    
    public string Password { get; set; } = "";

    public bool IsAdmin { get; set; }

    public Employee Employee {get;set;}=null!;
}