namespace Backend.Model;

public class Employee{
    public int UserId {get;set;}
    public User User {get;set;}=null!;

    public int DepartmentId {get;set;}
    public Department Department { get; set; } = null!;
}